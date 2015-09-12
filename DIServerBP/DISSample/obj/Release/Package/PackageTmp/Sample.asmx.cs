using System.Web.Services; 

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Xml;
using SAPbobsCOM;
using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using System.Net;
using System.Net.Mail;

namespace DISSample {
	[ System.Web.Services.WebService( Namespace="http://tempuri.org/DISSample/Sample" ) ]
	public class Sample : System.Web.Services.WebService 	{ 
		private const string sRem = "|Empty Node|"; 
        
		#region ' Web Services Designer Generated Code ' 
        
		public Sample() : base() { 
            
			// This call is required by the Web Services Designer.
			InitializeComponent(); 
            
			// Add your own initialization code after the InitializeComponent() call
            
		} 
        
		// Required by the Web Services Designer
		private System.ComponentModel.IContainer components; 
        
		// NOTE: The following procedure is required by the Web Services Designer
		// It can be modified using the Web Services Designer.  
		// Do not modify it using the code editor.
		[ System.Diagnostics.DebuggerStepThrough() ]
		private void InitializeComponent() { 
			components = new System.ComponentModel.Container(); 
		} 
                
		protected override void Dispose( bool disposing ) { 
			// CODEGEN: This procedure is required by the Web Services Designer
			// Do not modify it using the code editor.
			if ( disposing ) { 
				if ( !( ( components == null ) ) ){ 
					components.Dispose(); 
				} 
			} 
			base.Dispose( disposing ); 
		}         
        
		#endregion 

        [WebMethod()]
        public string getDocCotz(string idReport, string user_email)
        {
           
            try
            {
                ReportDocument cristalrp = new ReportDocument();
                cristalrp.Load(Server.MapPath("cotizacion.rpt"));
                cristalrp.SetParameterValue("DocKey@", idReport);

                cristalrp.SetDatabaseLogon("sa", "Cesehsa2010", "SERVIDOR-1", "Yukme-Pruebas");


                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                
                DateTime fecha = DateTime.Now; // Instancio un objeto DateTime
                string namefile = "c:\\Users\\Ventas\\Downloads\\cotz_" + idReport + "_" + fecha.Day.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Year.ToString() + ".pdf";

                CrDiskFileDestinationOptions.DiskFileName =  namefile;
                CrExportOptions = cristalrp.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                cristalrp.Export();
                //enviar peticion para ver en el navegador
                //ExportOptions exportOpts = new ExportOptions();
                //PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfRtfWordFormatOptions();
                //exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
                //exportOpts.ExportFormatOptions = pdfOpts;
                //cristalrp.ExportToHttpResponse(exportOpts, HttpContext.Current.Response, false, "");

                //enviar peticion de descarga
                //HttpContext.Current.Response.Clear();              
                //HttpContext.Current.Response.Buffer = false;
                //cristalrp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Cotización");

                try
                {
                   MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("email.appceseh@gmail.com");
                    mail.To.Add(user_email);
                    mail.Subject = "Cotización Cesehsa";
                    mail.Body = "Esperemos que te encuentres bien: Número de Cotización:"+ idReport;

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(namefile);
                    mail.Attachments.Add(attachment);

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("email.appceseh@gmail.com", "appceseh");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                                }catch(Exception e){
                                    return "fallo envío de email: "+e.Message;
                                }

                return "enviado";
            }catch (EngineException engEx)
             {
                return (engEx.Message);
            }
             
            
        }

        [WebMethod()]

        public string getCurrencyRate(string tipo, string SID)
        {
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();

            DateTime fecha = DateTime.Now; // Instancio un objeto DateTime
            string fechaToSap = fecha.ToString("yyyyMMdd");

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            sCmd += "<env:Header>";
            sCmd += "<SessionID>" + SID + "</SessionID>";
            sCmd += "</env:Header>";
            sCmd += "<env:Body>";
            sCmd += @"<dis:GetCurrencyRate xmlns:dis=""http://www.sap.com/SBO/DIS"">";
            sCmd += "<Currency>"+tipo+"</Currency>";
            sCmd += "<Date>"+fechaToSap+"</Date>";
            sCmd += "</dis:GetCurrencyRate>";
            sCmd += "</env:Body></env:Envelope>";

            sSOAPans = DISnode.Interact(sCmd);
            System.Xml.XmlValidatingReader xmlValid = null;
            string sRet = null;
            xmlValid = new System.Xml.XmlValidatingReader(sSOAPans, System.Xml.XmlNodeType.Document, null);
            while (xmlValid.Read())
            {
                if (xmlValid.NodeType == System.Xml.XmlNodeType.Text)
                {
                    if (sRet == null)
                    {
                        sRet += xmlValid.Value;
                    }
                    else
                    {
                        if (sRet.StartsWith("Error"))
                        {
                            
                        }
                        else
                        {
                            sRet = xmlValid.Value;
                        }
                    }
                }
            }
            if (Strings.InStr(sSOAPans, "<env:Fault>", Microsoft.VisualBasic.CompareMethod.Text) != 0)
            {
                sRet = "Error: " + sRet;
            }

            return sRet;
            
        }


        [WebMethod()]
        public string formatFecha(string ID) {
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            sCmd += "<env:Header>";
            sCmd += "<SessionID>" + ID + "</SessionID>";
            sCmd += "</env:Header>";
            sCmd += "<env:Body>";
            sCmd += @"<dis:Format_DateToString xmlns:dis=""http://www.sap.com/SBO/DIS"">";
            sCmd += "<inDate>20150804</inDate>";
            sCmd += "</dis:Format_DateToString>";
            sCmd += "</env:Body>";
            sCmd += "</env:Envelope>";


            //validacion del XML-,
            sSOAPans = DISnode.Interact(sCmd);
            System.Xml.XmlValidatingReader xmlValid = null;
            string sRet = null;
            xmlValid = new System.Xml.XmlValidatingReader(sSOAPans, System.Xml.XmlNodeType.Document, null);
            while (xmlValid.Read())
            {
                if (xmlValid.NodeType == System.Xml.XmlNodeType.Text)
                {
                    if (sRet == null)
                    {
                        sRet += xmlValid.Value;
                    }
                    else
                    {
                        if (sRet.StartsWith("Error"))
                        {
                            sRet += " " + xmlValid.Value;
                        }
                        else
                        {
                            sRet = xmlValid.Value;
                        }
                    }
                }
            }
            if (Strings.InStr(sSOAPans, "<env:Fault>", Microsoft.VisualBasic.CompareMethod.Text) != 0)
            {
                sRet = "Error: " + sRet;
            }

            return sRet;
        }

        [WebMethod()]
        public string getItemPrice(string ID) {

            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();
            System.Xml.XmlDocument dxml = null;

           sCmd =  @"<?xml version=""1.0"" encoding=""UTF-16""?>";
           sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
           sCmd += "<env:Header>";
           sCmd += "<SessionID>"+ID+"</SessionID>";
           sCmd += "</env:Header>";
           sCmd += "<env:Body>";
           sCmd += @"<dis:GetItemPrice xmlns:dis=""http://www.sap.com/SBO/DIS"">";
           sCmd += "<CardCode>P00009</CardCode>";
           sCmd += "<ItemCode>YP16-C-1-2.2-22</ItemCode>";
           sCmd += "<Quantity>1</Quantity>";
           sCmd += "<Date>04/08/2015</Date>";
           sCmd += "</dis:GetItemPrice>";
           sCmd += "</env:Body>";
           sCmd += "</env:Envelope>";


           sSOAPans = DISnode.Interact(sCmd);
           dxml = new System.Xml.XmlDocument();

           dxml.LoadXml(sSOAPans);

           String lista = null;
           String ss = AsString(RemoveEnv(dxml));
           lista = ss.Replace((char)34, (char)39);
           return lista;
        }

        [ WebMethod() ]
        public string getCotizacion(string CardCode, string SID, string Items)
        {
            System.Xml.XmlDocument d = null;
            d = new System.Xml.XmlDocument();
            //The list you want to fill
            ArrayList list = new ArrayList();
            
            XmlDocument doc = new XmlDocument();
            // Loading from a XML string (use Load() for file)
            doc.LoadXml(Items);

            // Selecting nodes using XPath syntax
            XmlNodeList idNodes = doc.SelectNodes("root/producto/id");
            XmlNodeList cantNodes = doc.SelectNodes("root/producto/cantidad");
            
            // initialization vars
            SBODI_Server.Node DISnode = null; 
			string sSOAPans = null, sCmd = null;             
			DISnode = new SBODI_Server.Node();
            
            // Filling the xml 
            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>"; 
			sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">"; 			
            sCmd += "<env:Header>";
            sCmd += "<SessionID>"+ SID +"</SessionID>";
            sCmd += "</env:Header>";
            sCmd += "<env:Body>";
            sCmd += @"<dis:AddObject xmlns:dis=""http://www.sap.com/SBO/DIS"">";
            sCmd += "<BOM><BO><AdmInfo>";
            sCmd += "<Object>oQuotations</Object>";
            sCmd += "</AdmInfo><Documents><row>";
            sCmd += "<CardCode>"+ CardCode +"</CardCode>";
            sCmd += "</row></Documents><Document_Lines>";
            
            foreach (XmlNode node in idNodes)
            {
                producto Item = new producto();
                Item.Id = node.InnerText;
                XmlNode cant = cantNodes.Item(list.Count);
                Item.Cantidad = cant.InnerText;
                list.Add(Item);

                sCmd += "<row>";
                sCmd += "<ItemCode>"+ Item.Id +"</ItemCode>";
                sCmd += "<Quantity>"+ Item.Cantidad +"</Quantity>";
                sCmd += "</row>";                               
            }
            sCmd += "</Document_Lines></BO></BOM></dis:AddObject></env:Body></env:Envelope>";

            //producto getP = (producto)list[1];
            //string id = (string)getP.Id;
            //string cantida = (string)getP.Cantidad;
            //return "id: "+id+"  cantidad: "+cantida;
             sSOAPans = DISnode.Interact(sCmd);


             
             System.Xml.XmlValidatingReader xmlValid = null;
             string sRet = null;
             xmlValid = new System.Xml.XmlValidatingReader(sSOAPans, System.Xml.XmlNodeType.Document, null);
             while (xmlValid.Read())
             {
                 if (xmlValid.NodeType == System.Xml.XmlNodeType.Text)
                 {
                     if (sRet == null)
                     {
                         sRet += xmlValid.Value;
                     }
                     else
                     {
                         if (sRet.StartsWith("Error"))
                         {
                             sRet += "" + xmlValid.Value;
                         }
                         else
                         {
                             
                         }
                     }
                 }
             }
             if (Strings.InStr(sSOAPans, "<env:Fault>", Microsoft.VisualBasic.CompareMethod.Text) != 0)
             {
                 sRet = "Error: " + sRet;
             }

             return sRet;
        }

		//  Login to DI Server
		[ WebMethod() ]
		public string Login(){ 
			SBODI_Server.Node DISnode = null; 
			string sSOAPans = null, sCmd = null; 
            
			DISnode = new SBODI_Server.Node(); 
            
			sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>"; 
			sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">"; 
			sCmd += @"<env:Body><dis:Login xmlns:dis=""http://www.sap.com/SBO/DIS"">"; 
			sCmd += "<DatabaseServer>" + "SERVIDOR-1" + "</DatabaseServer>";
            sCmd += "<DatabaseName>" + "Yukme-Pruebas" + "</DatabaseName>";
            sCmd += "<DatabaseType>" + "dst_MSSQL2008" + "</DatabaseType>"; 
			sCmd += "<DatabaseUsername>" + "sa" + "</DatabaseUsername>";
            sCmd += "<DatabasePassword>" + "Cesehsa2010" + "</DatabasePassword>"; 
			sCmd += "<CompanyUsername>" + "manager" + "</CompanyUsername>"; 
			sCmd += "<CompanyPassword>" + "12345" + "</CompanyPassword>";
            sCmd += "<Language>" + "ln_English" + "</Language>"; 
			sCmd += "<LicenseServer>" + "SERVIDOR-1:30000" + "</LicenseServer>"; // ILTLVH25
			sCmd += "</dis:Login></env:Body></env:Envelope>"; 
            
			sSOAPans = DISnode.Interact( sCmd ); 
            
			//  Parse the SOAP answer
			System.Xml.XmlValidatingReader xmlValid = null; 
			string sRet = null; 
			xmlValid = new System.Xml.XmlValidatingReader( sSOAPans, System.Xml.XmlNodeType.Document, null ); 
			while ( xmlValid.Read() ) { 
				if ( xmlValid.NodeType == System.Xml.XmlNodeType.Text )	{ 
					if ( sRet == null) { 
						sRet += xmlValid.Value; 
					} else { 
						if ( sRet.StartsWith( "Error" ) ) { 
							sRet += " " + xmlValid.Value; 
						} else{ 
							sRet = "Error " + sRet + " " + xmlValid.Value; 
						} 
					} 
				} 
			} 
			if ( Strings.InStr( sSOAPans, "<env:Fault>",Microsoft.VisualBasic.CompareMethod.Text) != 0){ 
				sRet = "Error: " + sRet; 
			} 
			return sRet; 
		}



        [WebMethod()]
        public String getStock(string SID) {
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();
            System.Xml.XmlDocument dxml = null;

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            sCmd += "<env:Header>";
            sCmd += "<SessionID>" + SID + "</SessionID>";
            sCmd += "</env:Header>";
            sCmd += "<env:Body>";
            sCmd += @"<dis:ExecuteSQL xmlns:dis=""http://www.sap.com/SBO/DIS"">";
            sCmd += "<DoQuery>";
            sCmd += "declare @grupo as table (articulo nvarchar(100),grupo1 nvarchar(50),grupo2 nvarchar (50),grupo3 nvarchar (50)) ";
            sCmd += "declare @OITG1 as table (Itemtypcod int,itmgrpnam nvarchar (200)) ";
            sCmd += "declare @OITG2 as table (Itemtypcod int,itmgrpnam nvarchar (200)) ";
            sCmd += "declare @OITG3 as table (Itemtypcod int,itmgrpnam nvarchar (200)) ";
            sCmd += "insert into @oitg1 select ItmsTypCod,itmsgrpnam from OITG where ItmsTypCod <16 ";
            sCmd += "insert into @oitg2 select ItmsTypCod,itmsgrpnam from OITG where ItmsTypCod >15 and ItmsTypCod < 41 ";
            sCmd += "insert into @oitg3 select ItmsTypCod,itmsgrpnam from OITG where ItmsTypCod >40 ";
            sCmd += "insert into @grupo select itemcode ,case "; // From OITM
            sCmd += "when QryGroup1='Y' then'1' ";
            sCmd += "when QryGroup2='Y' then'2' ";
            sCmd += "when QryGroup3='Y' then'3' ";
            sCmd += "when QryGroup4='Y' then'4' ";
            sCmd += "when QryGroup5='Y' then'5' ";
            sCmd += "when QryGroup6='Y' then'6' ";
            sCmd += "when QryGroup7='Y' then'7' ";
            sCmd += "when QryGroup8='Y' then'8' ";
            sCmd += "when QryGroup9='Y' then'9' ";
            sCmd += "when QryGroup10='Y' then '10' ";
            sCmd += "when QryGroup11='Y' then 11 ";
            sCmd += "when QryGroup12='Y' then 12 ";
            sCmd += "when QryGroup13='Y' then 13 ";
            sCmd += "when QryGroup14='Y' then 14 ";
            sCmd += "when QryGroup15='Y' then 15 ";
            sCmd += "else 64 end as 'grupo1', ";
            sCmd += "case when QryGroup16='Y'  then 16 ";
            sCmd += "when QryGroup17='Y' then 17 ";
            sCmd += "when QryGroup18='Y' then 18 ";
            sCmd += "when  QryGroup19='Y' then 19 ";
            sCmd += "when  QryGroup20='Y' then 20 ";
            sCmd += "when  QryGroup21='Y' then 21 ";
            sCmd += "when  QryGroup22='Y' then 22 ";
            sCmd += "when  QryGroup23='Y' then 23 ";
            sCmd += "when  QryGroup24='Y' then 24 ";
            sCmd += "when  QryGroup25='Y' then 25 ";
            sCmd += "when  QryGroup26='Y' then 26 ";
            sCmd += "when  QryGroup27='Y' then 27 ";
            sCmd += "when  QryGroup28='Y' then 28 ";
            sCmd += "when  QryGroup29='Y' then 29 ";
            sCmd += "when  QryGroup30='Y' then 30 ";
            sCmd += "when  QryGroup31='Y' then 31 ";
            sCmd += "when  QryGroup32='Y' then 32 ";
            sCmd += "when  QryGroup33='Y' then 33 ";
            sCmd += "when  QryGroup34='Y' then 34 ";
            sCmd += "when  QryGroup35='Y' then 35 ";
            sCmd += "when  QryGroup36='Y' then 36 ";
            sCmd += "when  QryGroup37='Y' then 37 ";
            sCmd += "when  QryGroup38='Y' then 38 ";
            sCmd += "when  QryGroup39='Y' then 39 ";
            sCmd += "when  QryGroup40='Y' then 40 ";
            sCmd += "else 64 end as 'grupo2', ";
            sCmd += "case ";
            sCmd += "when  QryGroup41='Y' then 41 ";
            sCmd += "when  QryGroup42='Y' then 42 ";
            sCmd += "when  QryGroup43='Y' then 43 ";
            sCmd += "when  QryGroup44='Y' then 44 ";
            sCmd += "when  QryGroup45='Y' then 45 ";
            sCmd += "When  QryGroup46='Y' then 46 ";
            sCmd += "when  QryGroup47='Y' then 47 ";
            sCmd += "when  QryGroup48='Y' then 48 ";
            sCmd += "when  QryGroup49='Y' then 49 ";
            sCmd += "when  QryGroup50='Y' then 50 ";
            sCmd += "when  QryGroup51='Y' then 51 ";
            sCmd += "when  QryGroup52='Y' then 52 ";
            sCmd += "when  QryGroup53='Y' then 53 ";
            sCmd += "when  QryGroup54='Y' then 54 ";
            sCmd += "when  QryGroup55='Y' then 55 ";
            sCmd += "when  QryGroup56='Y' then 56 ";
            sCmd += "when  QryGroup57='Y' then 57 ";
            sCmd += "when  QryGroup58='Y' then 58 ";
            sCmd += "when  QryGroup59='Y' then 59 ";
            sCmd += "when  QryGroup60='Y' then 60 ";
            sCmd += "when  QryGroup61='Y' then 61 ";
            sCmd += "when  QryGroup62='Y' then 62 ";
            sCmd += "when  QryGroup63='Y' then 63 ";
            sCmd += "else 64 end as 'grupo3' " ;
            sCmd += "FROM OITM ";
            sCmd += "SELECT T0.[ItemCode],T0.[ItemName],T3.[ItmsGrpNam], t5.itmgrpnam  ,t6.itmgrpnam ";
            sCmd += "FROM OITM T0 ";
            sCmd += "INNER JOIN OITM T1 ON T0.[ItemCode]=T1.[ItemCode] ";
            sCmd += "INNER JOIN OITW T8 ON T0.[ItemCode]=T8.[ItemCode] ";
            sCmd += "LEFT JOIN  OINV T2 ON T2.[DocEntry]=T0.[DocEntry] ";
            sCmd += "INNER JOIN OITB T3 ON  T1.[ItmsGrpCod]=T3.[ItmsGrpCod] ";
            sCmd += " LEFT JOIN @grupo t4  on t4.[articulo] =t1.[ItemCode] ";
            sCmd += "LEFT JOIN @OITG1 t5  on t4.[grupo1] =t5.[Itemtypcod] ";
            sCmd += "LEFT JOIN @OITG2 t6  on t4.[grupo2] = t6.[Itemtypcod] ";
            sCmd += "LEFT JOIN @OITG3 t7  on t4.[Grupo3] =t7.[Itemtypcod] ";
            sCmd += "Where T8.OnHand>=1 or T8.IsCommited>=1 and T8.OnOrder>=1 and T8.WhsCode  = '00' and T0.ItemName!='' ";
            sCmd += "order by T0.[ItemCode]";
            sCmd += "</DoQuery>";
            sCmd += "</dis:ExecuteSQL>";
            sCmd += "</env:Body>";
            sCmd += "</env:Envelope>";

            

            sSOAPans = DISnode.Interact(sCmd);
            dxml = new System.Xml.XmlDocument();

            dxml.LoadXml(sSOAPans);

            String lista = null;
            String ss = AsString(RemoveEnv(dxml));
            lista = ss.Replace((char)34, (char)39);
            return lista;
        }

        [WebMethod()]
        public string OrderService(string SID) { 

            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();
            System.Xml.XmlDocument dxml = null;

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"">";
            sCmd +="<env:Header>";
            sCmd +="<SessionID>"+ SID +"</SessionID>";
            sCmd += "</env:Header>";
            sCmd += "<env:Body>";
            sCmd += @"<dis:Add xmlns:dis=""http://www.sap.com/SBO/DIS"">";
            sCmd += "<Service>ProductionOrdersService</Service>";
            sCmd += "<ProductionOrder>";
            sCmd += "<Series>1047</Series>";
            sCmd += "<ItemNo>ProdFather</ItemNo>";
            sCmd += "<ProductionOrderStatus>boposPlanned</ProductionOrderStatus>";
            sCmd += "<ProductionOrderType>bopotDisassembly</ProductionOrderType>";
            sCmd += "<PlannedQuantity>2</PlannedQuantity>";
            sCmd += "<PostingDate>2015-06-16</PostingDate>";
            sCmd += "<DueDate>2015-06-16</DueDate>";
            sCmd += "<ProductionOrderOriginEntry>1</ProductionOrderOriginEntry>";
            sCmd += "<ProductionOrderOrigin>bopooManual</ProductionOrderOrigin>";
            sCmd += "<Remarks>remarks</Remarks>";
            sCmd += "<CustomerCode>ProdOrderBp</CustomerCode>";
            sCmd += "<Warehouse>02</Warehouse>";
            sCmd += "<JournalRemarks>Created by PO</JournalRemarks>";
            sCmd += "<ProductionOrderLines>";
            sCmd += "<ProductionOrderLine>";
            sCmd += "<ItemNo>ProdSon1</ItemNo>";
            sCmd += "<BaseQuantity>1</BaseQuantity>";
            sCmd += "<ProductionOrderIssueType>im_Manual</ProductionOrderIssueType>";
            sCmd += " <Warehouse>02</Warehouse>";
            sCmd += " </ProductionOrderLine>";
            sCmd += "</ProductionOrderLines>";
            sCmd += "</ProductionOrder>";
            sCmd += "</dis:Add>";
            sCmd += "</env:Body>";
            sCmd += "</env:Envelope>";
            sSOAPans = DISnode.Interact(sCmd);
           dxml = new System.Xml.XmlDocument();

           dxml.LoadXml(sSOAPans);

           String lista = null;
           String ss = AsString(RemoveEnv(dxml));
           lista = ss.Replace((char)34, (char)39);
           return lista;

        }
         /**
          * 
          * obteber detalle de un producto para la interfaz de detalle producto
          * 
          * */
        [WebMethod()]
        public string GetDetalle(string SID, string producto) { 
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();
            System.Xml.XmlDocument dxml = null;

           sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
           sCmd +=@"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
           sCmd +="<env:Header>";
           sCmd +="<SessionID>"+SID+"</SessionID>"; 
           sCmd +="</env:Header>";
           sCmd += "<env:Body>";
           sCmd += @"<dis:GetByKey xmlns:dis=""http://www.sap.com/SBO/DIS"">";
           sCmd += "<Object>oItems</Object>";
           sCmd += "<ItemCode>"+producto+"</ItemCode>";
           sCmd += "</dis:GetByKey>";
           sCmd += "</env:Body>";
           sCmd += "</env:Envelope>";

           sSOAPans = DISnode.Interact(sCmd);
           dxml = new System.Xml.XmlDocument();

           dxml.LoadXml(sSOAPans);

           String lista = null;
           String ss = AsString(RemoveEnv(dxml));
           lista = ss.Replace((char)34, (char)39);
           return lista;

        }

        [WebMethod()]
        public string GetItemList(string SID) {           
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();
            System.Xml.XmlDocument dxml = null;

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            sCmd += "<env:Header>";
            sCmd += "<SessionID>"+SID+"</SessionID>";
            sCmd += "</env:Header>";
            sCmd += "<env:Body>";
            sCmd += @"<dis:GetItemList xmlns:dis=""http://www.sap.com/SBO/DIS"">";
            sCmd += "</dis:GetItemList>";
            sCmd += "</env:Body>";
            sCmd += "</env:Envelope>";
            
            sSOAPans = DISnode.Interact(sCmd);
            dxml = new System.Xml.XmlDocument();
           
            dxml.LoadXml(sSOAPans);
            
            String lista = null;
            String ss = AsString(RemoveEnv(dxml));
            lista = ss.Replace((char)34, (char)39);
            return lista;

        }

		//  This function returns a list of Business Parnters in an XML format
		[ WebMethod() ]
		//public System.Xml.XmlDocument GetBPList( string SessionID) 
        public System.Xml.XmlDocument GetBPList( string SessionID, string CardType) { 
			SBODI_Server.Node DISnode = null; 
			string strSOAPans = null, strSOAPcmd = null; 
			System.Xml.XmlDocument xmlDoc = null; 
            
			xmlDoc = new System.Xml.XmlDocument(); 
			DISnode = new SBODI_Server.Node(); 
            
			strSOAPcmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetBPList xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<CardType>" + CardType + "</CardType>" + "</dis:GetBPList></env:Body></env:Envelope>";
            //  strSOAPcmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">"+"<env:Header>"+"<SessionID>"+ SessionID +"</SessionID>"+ @"</env:Header><env:Body><dis:GetItemList xmlns:dis=""http://www.sap.com/SBO/DIS"">"+"</dis:GetItemList></env:Body></env:Envelope>"; 
			strSOAPans = DISnode.Interact( strSOAPcmd ); 
			xmlDoc.LoadXml( strSOAPans ); 
			return ( RemoveEnv( xmlDoc ) ); 
		}                 

        [ WebMethod() ]
        public string GetTemplate(string SessionID){

            SBODI_Server.Node n = null;
            string s = null, strXML = null;
            System.Xml.XmlDocument d = null;

            d = new System.Xml.XmlDocument();
            n = new SBODI_Server.Node();

            strXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetBusinessObjectTemplate xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<Object>oQuotations</Object>" + "</dis:GetBusinessObjectTemplate></env:Body></env:Envelope>";
           
            s = n.Interact(strXML);
            d.LoadXml(s);
          //  return (RemoveEnv(d));
            return AsString(RemoveEnv(d));
        }
		//  This function returns an XML document of an empty Business Partner object
        //funcion que retorna lista completa de productos
		[ WebMethod() ]
		public System.Xml.XmlDocument GetEmptyBPXml( string SessionID ) 		{ 
			SBODI_Server.Node n = null; 
			string s = null, strXML = null; 
			System.Xml.XmlDocument d = null; 
            
			d = new System.Xml.XmlDocument(); 
			n = new SBODI_Server.Node(); 
            
			//strXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetBusinessObjectTemplate xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<Object>oBusinessPartners</Object>" + "</dis:GetBusinessObjectTemplate></env:Body></env:Envelope>";
            strXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetItemList xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "</dis:GetItemList>"+ "</env:Body>"+ "</env:Envelope>";
			s = n.Interact( strXML ); 
			d.LoadXml( s ); 
			return ( RemoveEnv( d ) ); 
		}

        [WebMethod()]
        public String AddLead(string id, string cardCode, string name, string tel, string email){
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();
            DateTime saveNow = DateTime.Now;      
            DateTime dateOnly = saveNow.Date;
            
            String date = dateOnly.ToString("d");
            String fecha = date.Replace("/", "");
            String Code = cardCode.Trim(new Char[] { 'L' });
            String rfc = fecha+Code; //6,7,8

            if (rfc.Length < 12)
            {
                rfc = "W" + rfc;
            }

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            sCmd += "<env:Header><SessionID>" + id + "</SessionID></env:Header><env:Body>";// ID de Sesion
            sCmd += @"<dis:AddObject xmlns:dis=""http://www.sap.com/SBO/DIS"" CommandID=""Add BP"">";
            sCmd += "<BOM><BO><AdmInfo><Object>oBusinessPartners</Object></AdmInfo>";
            sCmd += "<BusinessPartners>";
            sCmd += "<row>";
            sCmd += "<CardCode>" + cardCode + "</CardCode>";//como id de usario
            sCmd += "<CardName>" + name + "</CardName>"; //nombre de la empresa
            sCmd += "<CardType>cLid</CardType>";  //tipo de usuario 
            sCmd += "<GroupCode>100</GroupCode>"; //tipo de usuario final
            sCmd += "<ContactPerson>Ventas</ContactPerson>";//nombre de contacto
            sCmd += "<Phone1>" + tel + "</Phone1>";//telefono de contacto
            //sCmd += "<Phone2>" + phone + "</Phone2>";//telefono de contacto
            sCmd += "<EmailAddress>" + email + "</EmailAddress>"; //Direccion de correo electromico
            sCmd += "<FederalTaxID>" + rfc + "</FederalTaxID>";
            sCmd += "</row>";
            sCmd += "</BusinessPartners>";
            sCmd += "<ContactEmployees>";
            sCmd += "<row>";
            sCmd += "<CardCode>" + cardCode + "</CardCode>";
            sCmd += "<Name>Ventas</Name>";
            //sCmd += "<Position>manager</Position>";
            sCmd += "<Phone1>" + tel + "</Phone1>";
            sCmd += "<E_Mail>" + email + "</E_Mail>";
            //sCmd += "<InternalCode>613</InternalCode>";
            sCmd += "<FirstName>"+name+"</FirstName>";
            //sCmd += "<MiddleName nil='true'></MiddleName>";
            //sCmd += "<LastName>robles</LastName>";
            sCmd += "</row>";
            sCmd += "</ContactEmployees>";

            // sCmd += "<BPAddresses>";
            // sCmd += "<row>";
            // sCmd += "<AddressName>" + address + "</AddressName>";
            //sCmd += "</row>";
            // sCmd += "</BPAddresses>";//direccion de contacto
            sCmd += "</BO></BOM></dis:AddObject></env:Body></env:Envelope>";


            //validacion del XML-,
            sSOAPans = DISnode.Interact(sCmd);
            System.Xml.XmlValidatingReader xmlValid = null;
            string sRet = null;
            xmlValid = new System.Xml.XmlValidatingReader(sSOAPans, System.Xml.XmlNodeType.Document, null);
            while (xmlValid.Read())
            {
                if (xmlValid.NodeType == System.Xml.XmlNodeType.Text)
                {
                    if (sRet == null)
                    {
                        sRet += xmlValid.Value;
                    }
                    else
                    {
                        if (sRet.StartsWith("Error"))
                        {
                            sRet += " " + xmlValid.Value;
                        }
                        else
                        {
                            //sRet = "Error " + sRet + " " + xmlValid.Value;
                        }
                    }
                }
            }
            if (Strings.InStr(sSOAPans, "<env:Fault>", Microsoft.VisualBasic.CompareMethod.Text) != 0)
            {
                sRet = "Error: " + sRet;
            }

            return sRet;
        }

        [ WebMethod() ]
        public String addBP(String id, String cardCode,String Name,int Code,String phone,String email, String contactName,String RFC, String address){
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;

            DISnode = new SBODI_Server.Node();

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            sCmd += "<env:Header><SessionID>" + id + "</SessionID></env:Header><env:Body>";// ID de Sesion
            sCmd += @"<dis:AddObject xmlns:dis=""http://www.sap.com/SBO/DIS"" CommandID=""Add BP"">";
            sCmd += "<BOM><BO><AdmInfo><Object>oBusinessPartners</Object></AdmInfo>";
            sCmd += "<BusinessPartners>";
            sCmd += "<row>";
            sCmd += "<CardCode>" + cardCode + "</CardCode>";//como id de usario
            sCmd += "<CardName>" + Name + "</CardName>"; //nombre de la empresa
            sCmd += "<CardType>cCustomer</CardType>";  //tipo de usuario 
            sCmd += "<GroupCode>"+Code+"</GroupCode>"; //tipo de usuario final
          //sCmd += "<ContactPerson>" + contactName + "</ContactPerson>";//nombre de contacto
            sCmd += "<Phone1 nil='true'>"+phone+"</Phone1>";//telefono de contacto
            //sCmd += "<Phone2>" + phone + "</Phone2>";//telefono de contacto
            sCmd += "<EmailAddress>"+email+"</EmailAddress>"; //Direccion de correo electromico
            sCmd += "<FederalTaxID>"+RFC+"</FederalTaxID>";
            sCmd += "</row>";
            sCmd += "</BusinessPartners>";
            sCmd += "<ContactEmployees>";
            sCmd += "<row>";
            sCmd += "<CardCode>"+cardCode+"</CardCode>";
            sCmd += "<Name>"+contactName+"</Name>";
            sCmd += "<Position>manager</Position>";
            sCmd += "<Phone1>"+phone+"</Phone1>";
            sCmd += "<E_Mail>"+email+"</E_Mail>";
            sCmd += "<InternalCode>613</InternalCode>";
            sCmd += "<FirstName>julio</FirstName>";
            sCmd += "<MiddleName nil='true'></MiddleName>";
            sCmd += "<LastName>robles</LastName>";
            sCmd += "</row>";
            sCmd += "</ContactEmployees>";
                    
            sCmd += "<BPAddresses>";
            sCmd +=    "<row>";
            sCmd += "<AddressName>" + address + "</AddressName>";
            sCmd += "</row>";
            sCmd += "</BPAddresses>";//direccion de contacto
            sCmd += "</BO></BOM></dis:AddObject></env:Body></env:Envelope>";


            //validacion del XML-,
            sSOAPans = DISnode.Interact(sCmd);
            System.Xml.XmlValidatingReader xmlValid = null;
            string sRet = null;
            xmlValid = new System.Xml.XmlValidatingReader(sSOAPans, System.Xml.XmlNodeType.Document, null);
            while (xmlValid.Read()){
                if (xmlValid.NodeType == System.Xml.XmlNodeType.Text){
                    if (sRet == null){
                        sRet += xmlValid.Value;
                    } else{
                        if (sRet.StartsWith("Error")){
                            sRet += " " + xmlValid.Value;
                        } else{
                            sRet = "Error " + sRet + " " + xmlValid.Value;
                        }
                    }
                }
            }
            if (Strings.InStr(sSOAPans, "<env:Fault>", Microsoft.VisualBasic.CompareMethod.Text) != 0){
                sRet = "Error: " + sRet;
            }

            return sSOAPans;
        }


        public String detalleProducto(string SessionID)
        {
            SBODI_Server.Node n = null;
            string s = null, strXML = null;
            System.Xml.XmlDocument d = null;

            d = new System.Xml.XmlDocument();
            n = new SBODI_Server.Node();

            //strXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetBusinessObjectTemplate xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<Object>oBusinessPartners</Object>" + "</dis:GetBusinessObjectTemplate></env:Body></env:Envelope>";
            strXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetItemList xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "</dis:GetItemList>" + "</env:Body>" + "</env:Envelope>";
            s = n.Interact(strXML);
            d.LoadXml(s);
            return "";
        }

        
        public String SumLead(String Lead)
        {

            String numero;
            int tranf;
            numero = Lead.Trim(new Char[] { 'L' });

            tranf = Convert.ToInt32(numero);
            tranf++;
            return "L00" + tranf;
        }


        /**
         * 
         * funcion que nos regresa el ultimo numero de lead agregado
         * 
         * */
        [ WebMethod() ]
        public String getfinalLead(String id)
        {
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            sCmd += "<env:Header>";
            sCmd += "<SessionID>" + id + "</SessionID>";
            sCmd += "</env:Header>";
            sCmd += "<env:Body>";
            sCmd += @"<dis:ExecuteSQL xmlns:dis=""http://www.sap.com/SBO/DIS"">";
            sCmd += "<DoQuery>select top 1 CardCode from OCRD where CardCode LIKE 'L%' ORDER BY CardCode DESC</DoQuery>";
            sCmd += "</dis:ExecuteSQL>";
            sCmd += "</env:Body>";
            sCmd += "</env:Envelope>";

            //validacion del XML-,
            sSOAPans = DISnode.Interact(sCmd);
            System.Xml.XmlValidatingReader xmlValid = null;
            string sRet = null;
            xmlValid = new System.Xml.XmlValidatingReader(sSOAPans, System.Xml.XmlNodeType.Document, null);
            while (xmlValid.Read())
            {
                if (xmlValid.NodeType == System.Xml.XmlNodeType.Text)
                {
                    if (sRet == null)
                    {
                        sRet += xmlValid.Value;
                    }
                    else
                    {
                        if (sRet.StartsWith("Error"))
                        {
                            sRet += " " + xmlValid.Value;
                        }
                        else
                        {
                            sRet = xmlValid.Value;
                        }
                    }
                }
            }
            if (Strings.InStr(sSOAPans, "<env:Fault>", Microsoft.VisualBasic.CompareMethod.Text) != 0)
            {
                sRet = "Error: " + sRet;
            }

            return SumLead(sRet);

        }

        //  This function removes all the empty nodes from an XML document
        private System.Xml.XmlNode RemoveEmptyNodes(System.Xml.XmlNode n)
        {
            System.Xml.XmlNode nAns = null;

            nAns = MarkEmptyNodes(n);
            System.Xml.XmlNodeList nc = null;
            string sSelect = null;

            sSelect = @"//*[text()=""";
            sSelect += sRem;
            sSelect += @"""]";

            nc = nAns.SelectNodes(sSelect);
            foreach (System.Xml.XmlNode nN in nc)
            {
                nN.ParentNode.RemoveChild(nN);
            }
            return nAns;
        }

        //  This function marks all the empty nodes with special text.
        //  The "RemoveEmptyNodes" function uses it to select the nodes to be deleted.
        private System.Xml.XmlNode MarkEmptyNodes(System.Xml.XmlNode n)
        {
            System.Xml.XmlNode MainNode = null;
            MainNode = n;
            System.Xml.XmlNode nI = null;

            int i = 0, Removed = 0;
            i = 0;
            Removed = 0;

            for (i = 0; i <= MainNode.ChildNodes.Count - 1 - Removed; i++)
            {
                nI = MainNode.ChildNodes[i];
                if (nI.InnerText == "")
                {
                    nI.InnerText = sRem;
                }
                else if (nI.HasChildNodes)
                {
                    nI = MarkEmptyNodes(nI);
                }
            }
            return MainNode;
        }

        //  This function removes the SOAP envelope
        public System.Xml.XmlDocument RemoveEnv(System.Xml.XmlDocument xmlD)
        {
            System.Xml.XmlDocument d = null;
            string s = null;

            d = new System.Xml.XmlDocument();
            if (Strings.InStr(xmlD.InnerXml, "<env:Fault>", (Microsoft.VisualBasic.CompareMethod)(0)) != 0)
            {
                return xmlD;
            }
            else
            {
                s = xmlD.FirstChild.NextSibling.FirstChild.FirstChild.InnerXml;
                d.LoadXml(s);
            }

            return d;

        }

        public string AsString(System.Xml.XmlDocument xmlDoc)
        {

            using (StringWriter sw = new StringWriter())
            {

                using (XmlTextWriter tx = new XmlTextWriter(sw))
                {

                    xmlDoc.WriteTo(tx);
                    string strXmlText = sw.ToString();
                    return strXmlText;
                }
            }
        }

	} 
    
    
} 
