using System.Web.Services; 

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Web;
namespace DISSample 
{
	[ System.Web.Services.WebService( Namespace="http://tempuri.org/DISSample/Sample" ) ]
	public class Sample : System.Web.Services.WebService 
	{ 
		private const string sRem = "|Empty Node|"; 
        
		#region ' Web Services Designer Generated Code ' 
        
		public Sample() : base() 
		{ 
            
            
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
		private void InitializeComponent() 
		{ 
			components = new System.ComponentModel.Container(); 
		} 
        
        
		protected override void Dispose( bool disposing ) 
		{ 
			// CODEGEN: This procedure is required by the Web Services Designer
			// Do not modify it using the code editor.
			if ( disposing ) 
			{ 
				if ( !( ( components == null ) ) ) 
				{ 
					components.Dispose(); 
				} 
			} 
			base.Dispose( disposing ); 
		} 
        
        
		#endregion 
        
		//  Login to DI Server
		[ WebMethod() ]
		public string Login( string DataBaseServer, string DataBaseName, string DataBaseType, string DataBaseUserName, string DataBasePassword, string CompanyUserName, string CompanyPassword, string Language, string LicenseServer ) 
		{ 
			SBODI_Server.Node DISnode = null; 
			string sSOAPans = null, sCmd = null; 
            
			DISnode = new SBODI_Server.Node(); 
            
			sCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>"; 
			sCmd += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">"; 
			sCmd += @"<env:Body><dis:Login xmlns:dis=""http://www.sap.com/SBO/DIS"">"; 
			sCmd += "<DatabaseServer>" + DataBaseServer + "</DatabaseServer>"; 
			sCmd += "<DatabaseName>" + DataBaseName + "</DatabaseName>"; 
			sCmd += "<DatabaseType>" + DataBaseType + "</DatabaseType>"; 
			sCmd += "<DatabaseUsername>" + DataBaseUserName + "</DatabaseUsername>"; 
			sCmd += "<DatabasePassword>" + DataBasePassword + "</DatabasePassword>"; 
			sCmd += "<CompanyUsername>" + CompanyUserName + "</CompanyUsername>"; 
			sCmd += "<CompanyPassword>" + CompanyPassword + "</CompanyPassword>"; 
			sCmd += "<Language>" + Language + "</Language>"; 
			sCmd += "<LicenseServer>" + LicenseServer + "</LicenseServer>"; // ILTLVH25
			sCmd += "</dis:Login></env:Body></env:Envelope>"; 
            
			sSOAPans = DISnode.Interact( sCmd ); 
            
			//  Parse the SOAP answer
			System.Xml.XmlValidatingReader xmlValid = null; 
			string sRet = null; 
			xmlValid = new System.Xml.XmlValidatingReader( sSOAPans, System.Xml.XmlNodeType.Document, null ); 
			while ( xmlValid.Read() ) 
			{ 
				if ( xmlValid.NodeType == System.Xml.XmlNodeType.Text ) 
				{ 
					if ( sRet == null) 
					{ 
						sRet += xmlValid.Value; 
					} 
					else 
					{ 
						if ( sRet.StartsWith( "Error" ) ) 
						{ 
							sRet += " " + xmlValid.Value; 
						} 
						else 
						{ 
							sRet = "Error " + sRet + " " + xmlValid.Value; 
						} 
					} 
				} 
			} 
			if ( Strings.InStr( sSOAPans, "<env:Fault>",Microsoft.VisualBasic.CompareMethod.Text) != 0)
			{ 
				sRet = "Error: " + sRet; 
			} 
			return sRet; 
		} 
        
        
		//  This function returns a list of Business Parnters in an XML format
		[ WebMethod() ]
		public System.Xml.XmlDocument GetBPList( string SessionID, string CardType ) 
		{ 
			SBODI_Server.Node DISnode = null; 
			string strSOAPans = null, strSOAPcmd = null; 
			System.Xml.XmlDocument xmlDoc = null; 
            
			xmlDoc = new System.Xml.XmlDocument(); 
			DISnode = new SBODI_Server.Node(); 
            
			strSOAPcmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetBPList xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<CardType>" + CardType + "</CardType>" + "</dis:GetBPList></env:Body></env:Envelope>"; 
            
			strSOAPans = DISnode.Interact( strSOAPcmd ); 
			xmlDoc.LoadXml( strSOAPans ); 
			return ( RemoveEnv( xmlDoc ) ); 
		} 
        
        
		//  This function removes all the empty nodes from an XML document
		private System.Xml.XmlNode RemoveEmptyNodes( System.Xml.XmlNode n ) 
		{ 
			System.Xml.XmlNode nAns = null; 
            
			nAns = MarkEmptyNodes( n ); 
			System.Xml.XmlNodeList nc = null; 
			string sSelect = null; 
            
			sSelect = @"//*[text()="""; 
			sSelect += sRem; 
			sSelect += @"""]"; 
            
			nc = nAns.SelectNodes( sSelect ); 
			foreach ( System.Xml.XmlNode nN in nc ) 
			{ 
				nN.ParentNode.RemoveChild( nN ); 
			}
			return nAns; 
		} 
        
        
		//  This function marks all the empty nodes with special text.
		//  The "RemoveEmptyNodes" function uses it to select the nodes to be deleted.
		private System.Xml.XmlNode MarkEmptyNodes( System.Xml.XmlNode n ) 
		{ 
			System.Xml.XmlNode MainNode = null; 
			MainNode = n; 
			System.Xml.XmlNode nI = null; 
            
			int i = 0, Removed = 0; 
			i = 0; 
			Removed = 0; 
            
			for ( i=0; i<=MainNode.ChildNodes.Count - 1 - Removed; i++ ) 
			{ 
				nI = MainNode.ChildNodes[ i ]; 
				if ( nI.InnerText == "" ) 
				{ 
					nI.InnerText = sRem; 
				} 
				else if ( nI.HasChildNodes ) 
				{ 
					nI = MarkEmptyNodes( nI ); 
				} 
			} 
			return MainNode; 
		} 
        
        
		//  This function adds a Business Parnter
		[ WebMethod() ]
		public System.Xml.XmlDocument AddBP( string SessionID, string xmlBPObject ) 
		{ 
			SBODI_Server.Node n = null; 
			System.Xml.XmlDocument d = null, pXML = null; 
            
			d = new System.Xml.XmlDocument(); 
			n = new SBODI_Server.Node(); 
            
			string AddCmd = null; 
			System.Xml.XmlNode netoXML = null; 
            
			pXML = new System.Xml.XmlDocument(); 
			pXML.LoadXml( xmlBPObject ); 
            
			netoXML = ( RemoveEmptyNodes( pXML ) ); 
            
			AddCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:AddObject xmlns:dis=""http://www.sap.com/SBO/DIS"">" + netoXML.InnerXml + "</dis:AddObject></env:Body></env:Envelope>"; 
            
			string res = null; 
			res = n.Interact( AddCmd ); 
			d.LoadXml( res ); 
			return ( RemoveEnv( d ) ); 
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
        
        
		//  This function returns an XML document of an empty Business Partner object
		[ WebMethod() ]
		public System.Xml.XmlDocument GetEmptyBPXml( string SessionID ) 
		{ 
			SBODI_Server.Node n = null; 
			string s = null, strXML = null; 
			System.Xml.XmlDocument d = null; 
            
			d = new System.Xml.XmlDocument(); 
			n = new SBODI_Server.Node(); 
            
			strXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetBusinessObjectTemplate xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<Object>oBusinessPartners</Object>" + "</dis:GetBusinessObjectTemplate></env:Body></env:Envelope>"; 
            
			s = n.Interact( strXML ); 
			d.LoadXml( s ); 
			return ( RemoveEnv( d ) ); 
		} 
        
        
	} 
    
    
} 
