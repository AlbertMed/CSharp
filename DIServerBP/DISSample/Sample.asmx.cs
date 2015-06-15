using System.Web.Services; 

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Xml;
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
        
        
		//  This function removes all the empty nodes from an XML document
		private System.Xml.XmlNode RemoveEmptyNodes( System.Xml.XmlNode n ){ 
			System.Xml.XmlNode nAns = null; 
            
			nAns = MarkEmptyNodes( n ); 
			System.Xml.XmlNodeList nc = null; 
			string sSelect = null; 
            
			sSelect = @"//*[text()="""; 
			sSelect += sRem; 
			sSelect += @"""]"; 
            
			nc = nAns.SelectNodes( sSelect ); 
			foreach ( System.Xml.XmlNode nN in nc ) { 
				nN.ParentNode.RemoveChild( nN ); 
			}
			return nAns; 
		} 
        
        
		//  This function marks all the empty nodes with special text.
		//  The "RemoveEmptyNodes" function uses it to select the nodes to be deleted.
		private System.Xml.XmlNode MarkEmptyNodes( System.Xml.XmlNode n ){ 
			System.Xml.XmlNode MainNode = null; 
			MainNode = n; 
			System.Xml.XmlNode nI = null; 
            
			int i = 0, Removed = 0; 
			i = 0; 
			Removed = 0; 
            
			for ( i=0; i<=MainNode.ChildNodes.Count - 1 - Removed; i++ ) { 
				nI = MainNode.ChildNodes[ i ]; 
				if ( nI.InnerText == "" ) { 
					nI.InnerText = sRem; 
				} else if ( nI.HasChildNodes ){ 
					nI = MarkEmptyNodes( nI ); 
				} 
			} 
			return MainNode; 
		} 
       
        
		//  This function removes the SOAP envelope
		public System.Xml.XmlDocument RemoveEnv( System.Xml.XmlDocument xmlD ) 
		{ 
			System.Xml.XmlDocument d = null; 
			string s = null; 
            
			d = new System.Xml.XmlDocument(); 
			if ( Strings.InStr( xmlD.InnerXml, "<env:Fault>", (Microsoft.VisualBasic.CompareMethod)(0) )!=0 ) 
			{ 
				return xmlD; 
			} 
			else 
			{ 
				s = xmlD.FirstChild.NextSibling.FirstChild.FirstChild.InnerXml; 
				d.LoadXml( s ); 
			} 
            
			return d; 
            
		}        

      
        public string AsString(System.Xml.XmlDocument xmlDoc) {

            using (StringWriter sw = new StringWriter()) {

                using (XmlTextWriter tx = new XmlTextWriter(sw)) {

                    xmlDoc.WriteTo(tx);
                    string strXmlText = sw.ToString();
                    return strXmlText;
                }
            }
        }

        [ WebMethod() ]
        public string GetDataFull(string SessionID){

            SBODI_Server.Node n = null;
            string s = null, strXML = null;
            System.Xml.XmlDocument d = null;

            d = new System.Xml.XmlDocument();
            n = new SBODI_Server.Node();

            strXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetBusinessObjectTemplate xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<Object>oBusinessPartners</Object>" + "</dis:GetBusinessObjectTemplate></env:Body></env:Envelope>";
           
            s = n.Interact(strXML);
            d.LoadXml(s);
          //  return (RemoveEnv(d));
            return AsString(RemoveEnv(d));
        }

		//  This function returns an XML document of an empty Business Partner object
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

        [WebMethod()]
        public String SumLead(String Lead) {
            
            String numero;
            int tranf;
            numero = Lead.Trim( new Char[] {'L'} );
           
            tranf = Convert.ToInt32(numero);
            tranf ++;
            return "L00"+tranf;
        }

        [WebMethod()]
        public String getfinalLead(String id) { 
            SBODI_Server.Node DISnode = null;
            string sSOAPans = null, sCmd = null;
            DISnode = new SBODI_Server.Node();

            sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            sCmd += "<env:Header>";
            sCmd += "<SessionID>"+id+"</SessionID>";
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
                    if (sRet == null) {
                        sRet += xmlValid.Value;
                    }else
                    {
                        if (sRet.StartsWith("Error")) {
                            sRet += " " + xmlValid.Value;
                        }
                        else{
                            sRet = xmlValid.Value;
                        }
                    }
                }
            }
            if (Strings.InStr(sSOAPans, "<env:Fault>", Microsoft.VisualBasic.CompareMethod.Text) != 0) {
                sRet = "Error: " + sRet;
            }

            return sRet;

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
	} 
    
    
} 
