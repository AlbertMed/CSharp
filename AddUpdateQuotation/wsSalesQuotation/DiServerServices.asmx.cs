// //  SAP MANAGE DI Server Api VERSION 2006 SDK Sample
// //****************************************************************************
// //
// //  File:      DiServerServices.asmx
// //
// //  Copyright (c) SAP MANAGE
// //
// // THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// // ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// // THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// // PARTICULAR PURPOSE.
// //
// //****************************************************************************


using System.Web.Services; 

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Web;
namespace wsSalesQuotation {
    [ System.Web.Services.WebService( Namespace="http://tempuri.org/wsSalesQuotation/Service1" ) ]
    public class DiServerServicesSample : System.Web.Services.WebService { 
        private const string sRem = "|Empty Node|"; 
        
        #region ' Web Services Designer Generated Code ' 
        
        public DiServerServicesSample() : base() { 
            
            
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
                if ( !( ( components == null ) ) ) { 
                    components.Dispose(); 
                } 
            } 
            base.Dispose( disposing ); 
        } 
        
        
        #endregion 
        
        //  Login to company
        [ WebMethod( Description="Login to company" ) ]
        public string Login( string DataBaseServer, string DataBaseName, string DataBaseType, string DataBaseUserName, string DataBasePassword, string CompanyUserName, string CompanyPassword, string Language, string LicenseServer) { 
            
            SBODI_Server.Node pDISnode = null; 
            string sSOAPans = null; 
            string sCmd = null; 
            string sRetVal = null; 
            
            pDISnode = new SBODI_Server.Node(); 
            
            // build the soap string
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
            sCmd += "<LicenseServer>" + LicenseServer + "</LicenseServer>"; 
            sCmd += "</dis:Login></env:Body></env:Envelope>"; 
            
            // execute di-server interact and return the result
            sSOAPans = pDISnode.Interact( sCmd ); 
            
            // get parsed result
            sRetVal = GetParseResultFromSoapAnswer( sSOAPans ); 
            
            // return result
            return sRetVal; 
            
        } 
        
        
        //  Logout
        [ WebMethod( Description="LogOut to company" ) ]
        public object LogOut( string sSessionID ) { 
            
            SBODI_Server.Node pDISnode = null; 
            string sSOAPans = null; 
            string sCmdXml = null; 
            string sRetVal = null; 
            
            pDISnode = new SBODI_Server.Node(); 
            
            // build the soap string
            sCmdXml = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + sSessionID + "</SessionID>" + "</env:Header>" + "<env:Body>" + @"<dis:Logout xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "</dis:Logout>" + "</env:Body>" + "</env:Envelope>"; 
            
            // execute interact and return the result
            sSOAPans = pDISnode.Interact( sCmdXml ); 
            
            // return result
            return sSOAPans; 
            
        } 
        
        
        // return the result from the soap string
        private string GetParseResultFromSoapAnswer( string sSOAPans ) { 
            
            
            System.Xml.XmlValidatingReader pXmlValid = null; 
            string sRet = ""; 
            
            // get xml reader
            pXmlValid = new System.Xml.XmlValidatingReader( sSOAPans, System.Xml.XmlNodeType.Document, null ); 
            
            //  Parse the SOAP answer    
            while ( pXmlValid.Read() ) { 
                if ( pXmlValid.NodeType == System.Xml.XmlNodeType.Text ) { 
                    if ( sRet == "" ) { 
                        sRet += pXmlValid.Value; 
                    } 
                    else { 
                        if ( sRet.StartsWith( "Error" ) ) { 
                            sRet += " " + pXmlValid.Value; 
                        } 
                        else { 
                            sRet = "Error " + sRet + " " + pXmlValid.Value; 
                        } 
                    } 
                } 
            } 
            
            // check for errors
            if ( (Strings.InStr( sSOAPans, "<env:Fault>", (Microsoft.VisualBasic.CompareMethod)(0) ) & System.Convert.ToInt32( ( !( ( sRet.StartsWith( "Error" ) ) ) ) ))>0 ) { 
                sRet = "Error: " + sRet; 
            } 
            
            // return result
            return sRet; 
            
        } 
        
        
        //  This function returns an XML document of an empty Quotation object
        [ WebMethod( Description="Get an XML document of an empty Quotation object" ) ]
        public System.Xml.XmlDocument GetEmptyQuotationXml( string sSessionID ) { 
            
            
            SBODI_Server.Node pDISnode = null; 
            string sReturnStr = null; 
            string sCmdXML = null; 
            System.Xml.XmlDocument pXmlReturn = null; 
            
            pXmlReturn = new System.Xml.XmlDocument(); 
            
            // get new di-server node
            pDISnode = new SBODI_Server.Node(); 
            
            // build the soap string, adding the session, the command-GetBusinessObjectTemplate,
            // and the object - oQuotations
            sCmdXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + sSessionID + "</SessionID>" + @"</env:Header><env:Body><dis:GetBusinessObjectTemplate xmlns:dis=""http://www.sap.com/SBO/DIS"">" + "<Object>oQuotations</Object>" + "</dis:GetBusinessObjectTemplate></env:Body></env:Envelope>"; 
            
            // execute interact and return the result
            sReturnStr = pDISnode.Interact( sCmdXML ); 
            
            // load the string to xml document
            pXmlReturn.LoadXml( sReturnStr ); 
            
            // remove the envelope string & return the result as XmlDocument
            return ( RemoveEnv( pXmlReturn ) ); 
            
        } 
        
        
        
        //  This function removes the SOAP envelope
        private System.Xml.XmlDocument RemoveEnv( System.Xml.XmlDocument pXmlReceive ) { 
            
            System.Xml.XmlDocument pXmlDoc = null; 
            string sResult = null; 
            
            pXmlDoc = new System.Xml.XmlDocument(); 
            
            // check for error
            if ( (Strings.InStr( pXmlReceive.InnerXml, "<env:Fault>", (Microsoft.VisualBasic.CompareMethod)(0) ))>0) { 
                // return the xml document 
                return pXmlReceive; 
            } 
            else { 
                // get the answer without the envelope    
                sResult = pXmlReceive.FirstChild.NextSibling.FirstChild.FirstChild.InnerXml; 
                // load to the xml document
                pXmlDoc.LoadXml( sResult ); 
            } 
            
            // return result
            return pXmlDoc; 
            
        } 
        
        
        //  This function Add Sales Quotation
        [ WebMethod( Description="Add Sales Quotation" ) ]
        public System.Xml.XmlDocument AddQuotation( string SessionID, string sXmlQuotationObject ) { 
            
            SBODI_Server.Node pDISnode = null; 
            System.Xml.XmlDocument pXmlReturn = null, pXML = null; 
            string sAddCmd = null; 
            System.Xml.XmlNode pNetoXML = null; 
            string sResult = null; 
            
            
            pXmlReturn = new System.Xml.XmlDocument(); 
            
            // get server node
            pDISnode = new SBODI_Server.Node(); 
            
            pXML = new System.Xml.XmlDocument(); 
            
            // load the string into xml document
            pXML.LoadXml( sXmlQuotationObject ); 
            
            // remove the empty nodes
            pNetoXML = ( RemoveEmptyNodes( pXML ) ); 
            
            
            // build the soap string ,adding the session, the command-AddObject
            // and the XmlQuotation string
            sAddCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + SessionID + "</SessionID>" + @"</env:Header><env:Body><dis:AddObject xmlns:dis=""http://www.sap.com/SBO/DIS"">" + pNetoXML.InnerXml + "</dis:AddObject></env:Body></env:Envelope>"; 
            
            
            
            // execute interact and return the result
            sResult = pDISnode.Interact( sAddCmd ); 
            
            // load string to xml document
            pXmlReturn.LoadXml( sResult ); 
            
            // remove the envelope string & return the result as XmlDocument
            return ( RemoveEnv( pXmlReturn ) ); 
            
        } 
        
        
        
        //  This function removes all the empty nodes from an XML document
        private System.Xml.XmlNode RemoveEmptyNodes( System.Xml.XmlNode pXmlReceive ) { 
            
            System.Xml.XmlNode pXmlAnswer = null; 
            System.Xml.XmlNodeList pXmlNodeList = null; 
            string sSelect = null; 
            System.Xml.XmlNode pTempXml = null; 
            
            pXmlAnswer = MarkEmptyNodes( pXmlReceive ); 
            
            // build the marked string
            sSelect = @"//*[text()="""; 
            sSelect += sRem; 
            sSelect += @"""]"; 
            
            // get node list
            pXmlNodeList = pXmlAnswer.SelectNodes( sSelect ); 
            
            // remove the marked nodes
            foreach ( System.Xml.XmlNode transTemp0 in pXmlNodeList ) { 
                pTempXml = transTemp0; /* TRANSWARNING: check temp variable in foreach */ 
                pTempXml.ParentNode.RemoveChild( pTempXml ); 
            }
            
            // return answer
            return pXmlAnswer; 
            
        } 
        
        
        //  This function marks all the empty nodes with special text.
        //  The "RemoveEmptyNodes" function uses it to select the nodes to be deleted.
        private System.Xml.XmlNode MarkEmptyNodes( System.Xml.XmlNode pXmlReceive ) { 
            
            System.Xml.XmlNode pMainNode = null; 
            System.Xml.XmlNode pXmlTemp = null; 
            int i = 0, Removed = 0; 
            
            pMainNode = pXmlReceive; 
            
            i = 0; 
            
            Removed = 0; 
            
            // mark empty nodes
            for ( i=0; i<=pMainNode.ChildNodes.Count - 1 - Removed; i++ ) { 
                pXmlTemp = pMainNode.ChildNodes[ i ]; 
                if ( pXmlTemp.InnerText == "" ) { 
                    pXmlTemp.InnerText = sRem; 
                } 
                else if ( pXmlTemp.HasChildNodes ) { 
                    pXmlTemp = MarkEmptyNodes( pXmlTemp ); 
                } 
            } 
            
            // return answer
            return pMainNode; 
            
        } 
        
        
        //  The function gets the xml string adds the header and send it to the di-server for update 
        [ WebMethod( Description="Update Quotation object" ) ]
        public System.Xml.XmlDocument UpdateQuotation( string sSessionID, string sXmlQuotationObject ) { 
            
            System.Xml.XmlDocument pReturnXml = null; 
            System.Xml.XmlDocument pXML = null; 
            SBODI_Server.Node pDiServerNode = null; 
            string sResult = null; 
            string sAddCmd = null; 
            
            pXML = new System.Xml.XmlDocument(); 
            
            // load string to xml document
            pXML.LoadXml( sXmlQuotationObject ); 
            
            // build the soap string ,adding the session, the command-UpdateObject
            // and the XmlQuotation string
            sAddCmd = @"<?xml version=""1.0"" encoding=""UTF-16""?>" + @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">" + "<env:Header>" + "<SessionID>" + sSessionID + "</SessionID>" + "</env:Header><env:Body>" + @"<dis:UpdateObject xmlns:dis=""http://www.sap.com/SBO/DIS"">" + pXML.InnerXml + "</dis:UpdateObject></env:Body></env:Envelope>"; 
            
            pDiServerNode = new SBODI_Server.Node(); 
            
            // execute interact and return the result
            sResult = pDiServerNode.Interact( sAddCmd ); 
            
            pReturnXml = new System.Xml.XmlDocument(); 
            
            // load result to xml document
            pReturnXml.LoadXml( sResult ); 
            
            // return result
            return ( RemoveEnv(pReturnXml) ); 
            
        } 
        
        
    } 
    
    
} 
