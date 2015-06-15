//  SAP MANAGE DI Server Api VERSION 2006 SDK Sample
//****************************************************************************
//
//  File:      frmSalesQuotation.cs
//
//  Copyright (c) SAP MANAGE
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
//****************************************************************************


using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
namespace SalesQuotationClient {
    public class SalesQuotationForm : System.Windows.Forms.Form { 
        
        #region ' Windows Form Designer generated code ' 
        
        public SalesQuotationForm() : base() { 
            
            
            // This call is required by the Windows Form Designer.
            InitializeComponent(); 
            
            // Add any initialization after the InitializeComponent() call
            
        } 
        
        // Form overrides dispose to clean up the component list.
        protected override void Dispose( bool disposing ) { 
            if ( disposing ) { 
                if ( !( ( components == null ) ) ) { 
                    components.Dispose(); 
                } 
            } 
            base.Dispose( disposing ); 
        } 
        
        
        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components; 
        
        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        internal System.Windows.Forms.Button cmdAddQuotation; 
        internal System.Windows.Forms.TextBox txtXml; 
        internal System.Windows.Forms.Button cmdUpdate; 
        internal System.Windows.Forms.TextBox txtUpdate; 
        internal System.Windows.Forms.TextBox txtBpCode; 
        internal System.Windows.Forms.Label Label11; 
        internal System.Windows.Forms.Label Label12; 
        internal System.Windows.Forms.TextBox txtItemCode; 
        internal System.Windows.Forms.Label Label13; 
        internal System.Windows.Forms.TextBox txtItemQuantity; 
        internal System.Windows.Forms.TextBox txtUpQuantity; 
        internal System.Windows.Forms.Label Label14; 
        internal System.Windows.Forms.Label Label15; 
        internal System.Windows.Forms.TextBox txtUpItemCode; 
        internal System.Windows.Forms.Label lblDoc; 
        internal System.Windows.Forms.TextBox txtDocNo; 
        internal System.Windows.Forms.TextBox txtItem2Quant; 
        internal System.Windows.Forms.Label Label16; 
        internal System.Windows.Forms.Label Label17; 
        internal System.Windows.Forms.TextBox txtItem2Code; 
        internal System.Windows.Forms.GroupBox GroupBox1; 
        internal System.Windows.Forms.TextBox txtSessID; 
        internal System.Windows.Forms.TextBox txtLicenseServer; 
        internal System.Windows.Forms.Label Label9; 
        internal System.Windows.Forms.TextBox txtLanguage; 
        internal System.Windows.Forms.Label Label8; 
        internal System.Windows.Forms.TextBox txtCompanyPassword; 
        internal System.Windows.Forms.Label Label7; 
        internal System.Windows.Forms.TextBox txtCompanyUserName; 
        internal System.Windows.Forms.Label Label6; 
        internal System.Windows.Forms.TextBox txtDataBasePassword; 
        internal System.Windows.Forms.Label Label5; 
        internal System.Windows.Forms.TextBox txtDataBaseUserName; 
        internal System.Windows.Forms.Label Label4; 
        internal System.Windows.Forms.Label Label3; 
        internal System.Windows.Forms.TextBox txtDataBaseName; 
        internal System.Windows.Forms.Label Label2; 
        internal System.Windows.Forms.TextBox txtDataBaseServer; 
        internal System.Windows.Forms.Label Label1; 
        internal System.Windows.Forms.Button cmdLogInComp;
		internal System.Windows.Forms.TextBox txtPort;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.ComboBox txtDataBaseType; 
        internal System.Windows.Forms.Button cmdLogOut; 
        [ System.Diagnostics.DebuggerStepThrough() ]
        private void InitializeComponent() { 
			this.cmdAddQuotation = new System.Windows.Forms.Button();
			this.txtXml = new System.Windows.Forms.TextBox();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.txtUpdate = new System.Windows.Forms.TextBox();
			this.txtBpCode = new System.Windows.Forms.TextBox();
			this.txtItemCode = new System.Windows.Forms.TextBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.txtItemQuantity = new System.Windows.Forms.TextBox();
			this.txtUpQuantity = new System.Windows.Forms.TextBox();
			this.Label14 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.txtUpItemCode = new System.Windows.Forms.TextBox();
			this.lblDoc = new System.Windows.Forms.Label();
			this.txtDocNo = new System.Windows.Forms.TextBox();
			this.txtItem2Quant = new System.Windows.Forms.TextBox();
			this.Label16 = new System.Windows.Forms.Label();
			this.Label17 = new System.Windows.Forms.Label();
			this.txtItem2Code = new System.Windows.Forms.TextBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cmdLogOut = new System.Windows.Forms.Button();
			this.txtSessID = new System.Windows.Forms.TextBox();
			this.cmdLogInComp = new System.Windows.Forms.Button();
			this.txtLicenseServer = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.txtLanguage = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.txtCompanyPassword = new System.Windows.Forms.TextBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.txtCompanyUserName = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtDataBasePassword = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtDataBaseUserName = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtDataBaseName = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtDataBaseServer = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtDataBaseType = new System.Windows.Forms.ComboBox();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdAddQuotation
			// 
			this.cmdAddQuotation.Location = new System.Drawing.Point(16, 224);
			this.cmdAddQuotation.Name = "cmdAddQuotation";
			this.cmdAddQuotation.Size = new System.Drawing.Size(96, 24);
			this.cmdAddQuotation.TabIndex = 44;
			this.cmdAddQuotation.Text = "Add Quotation";
			this.cmdAddQuotation.Click += new System.EventHandler(this.cmdAddQuotation_Click);
			// 
			// txtXml
			// 
			this.txtXml.Location = new System.Drawing.Point(16, 304);
			this.txtXml.Multiline = true;
			this.txtXml.Name = "txtXml";
			this.txtXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtXml.Size = new System.Drawing.Size(352, 152);
			this.txtXml.TabIndex = 46;
			this.txtXml.Text = "";
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.Location = new System.Drawing.Point(400, 224);
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.Size = new System.Drawing.Size(96, 24);
			this.cmdUpdate.TabIndex = 48;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
			// 
			// txtUpdate
			// 
			this.txtUpdate.Location = new System.Drawing.Point(400, 304);
			this.txtUpdate.Multiline = true;
			this.txtUpdate.Name = "txtUpdate";
			this.txtUpdate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtUpdate.Size = new System.Drawing.Size(264, 152);
			this.txtUpdate.TabIndex = 49;
			this.txtUpdate.Text = "";
			// 
			// txtBpCode
			// 
			this.txtBpCode.Location = new System.Drawing.Point(176, 224);
			this.txtBpCode.Name = "txtBpCode";
			this.txtBpCode.Size = new System.Drawing.Size(56, 20);
			this.txtBpCode.TabIndex = 50;
			this.txtBpCode.Text = "HU1003";
			// 
			// txtItemCode
			// 
			this.txtItemCode.Location = new System.Drawing.Point(176, 248);
			this.txtItemCode.Name = "txtItemCode";
			this.txtItemCode.Size = new System.Drawing.Size(56, 20);
			this.txtItemCode.TabIndex = 51;
			this.txtItemCode.Text = "A00001";
			// 
			// Label11
			// 
			this.Label11.Location = new System.Drawing.Point(120, 248);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(56, 16);
			this.Label11.TabIndex = 52;
			this.Label11.Text = "Item Code";
			// 
			// Label12
			// 
			this.Label12.Location = new System.Drawing.Point(120, 226);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(56, 16);
			this.Label12.TabIndex = 53;
			this.Label12.Text = "BP Code";
			// 
			// Label13
			// 
			this.Label13.Location = new System.Drawing.Point(128, 272);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(40, 16);
			this.Label13.TabIndex = 54;
			this.Label13.Text = "Quatity";
			// 
			// txtItemQuantity
			// 
			this.txtItemQuantity.Location = new System.Drawing.Point(176, 272);
			this.txtItemQuantity.Name = "txtItemQuantity";
			this.txtItemQuantity.Size = new System.Drawing.Size(56, 20);
			this.txtItemQuantity.TabIndex = 55;
			this.txtItemQuantity.Text = "1";
			// 
			// txtUpQuantity
			// 
			this.txtUpQuantity.Location = new System.Drawing.Point(568, 272);
			this.txtUpQuantity.Name = "txtUpQuantity";
			this.txtUpQuantity.TabIndex = 59;
			this.txtUpQuantity.Text = "3";
			// 
			// Label14
			// 
			this.Label14.Location = new System.Drawing.Point(512, 272);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(40, 16);
			this.Label14.TabIndex = 58;
			this.Label14.Text = "Quatity";
			// 
			// Label15
			// 
			this.Label15.Location = new System.Drawing.Point(504, 248);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(56, 16);
			this.Label15.TabIndex = 57;
			this.Label15.Text = "Item Code";
			// 
			// txtUpItemCode
			// 
			this.txtUpItemCode.Location = new System.Drawing.Point(568, 248);
			this.txtUpItemCode.Name = "txtUpItemCode";
			this.txtUpItemCode.TabIndex = 56;
			this.txtUpItemCode.Text = "A00001";
			// 
			// lblDoc
			// 
			this.lblDoc.Location = new System.Drawing.Point(504, 224);
			this.lblDoc.Name = "lblDoc";
			this.lblDoc.Size = new System.Drawing.Size(56, 16);
			this.lblDoc.TabIndex = 61;
			this.lblDoc.Text = "Doc No.";
			// 
			// txtDocNo
			// 
			this.txtDocNo.Location = new System.Drawing.Point(568, 224);
			this.txtDocNo.Name = "txtDocNo";
			this.txtDocNo.TabIndex = 60;
			this.txtDocNo.Text = "";
			// 
			// txtItem2Quant
			// 
			this.txtItem2Quant.Location = new System.Drawing.Point(304, 272);
			this.txtItem2Quant.Name = "txtItem2Quant";
			this.txtItem2Quant.Size = new System.Drawing.Size(64, 20);
			this.txtItem2Quant.TabIndex = 65;
			this.txtItem2Quant.Text = "2";
			// 
			// Label16
			// 
			this.Label16.Location = new System.Drawing.Point(248, 272);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(40, 16);
			this.Label16.TabIndex = 64;
			this.Label16.Text = "Quatity";
			// 
			// Label17
			// 
			this.Label17.Location = new System.Drawing.Point(248, 248);
			this.Label17.Name = "Label17";
			this.Label17.Size = new System.Drawing.Size(56, 16);
			this.Label17.TabIndex = 63;
			this.Label17.Text = "Item Code";
			// 
			// txtItem2Code
			// 
			this.txtItem2Code.Location = new System.Drawing.Point(304, 248);
			this.txtItem2Code.Name = "txtItem2Code";
			this.txtItem2Code.Size = new System.Drawing.Size(64, 20);
			this.txtItem2Code.TabIndex = 62;
			this.txtItem2Code.Text = "A00002";
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.txtPort);
			this.GroupBox1.Controls.Add(this.label10);
			this.GroupBox1.Controls.Add(this.cmdLogOut);
			this.GroupBox1.Controls.Add(this.txtSessID);
			this.GroupBox1.Controls.Add(this.cmdLogInComp);
			this.GroupBox1.Controls.Add(this.txtLicenseServer);
			this.GroupBox1.Controls.Add(this.Label9);
			this.GroupBox1.Controls.Add(this.txtLanguage);
			this.GroupBox1.Controls.Add(this.Label8);
			this.GroupBox1.Controls.Add(this.txtCompanyPassword);
			this.GroupBox1.Controls.Add(this.Label7);
			this.GroupBox1.Controls.Add(this.txtCompanyUserName);
			this.GroupBox1.Controls.Add(this.Label6);
			this.GroupBox1.Controls.Add(this.txtDataBasePassword);
			this.GroupBox1.Controls.Add(this.Label5);
			this.GroupBox1.Controls.Add(this.txtDataBaseUserName);
			this.GroupBox1.Controls.Add(this.Label4);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.txtDataBaseName);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.txtDataBaseServer);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.txtDataBaseType);
			this.GroupBox1.Location = new System.Drawing.Point(16, 8);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(664, 168);
			this.GroupBox1.TabIndex = 66;
			this.GroupBox1.TabStop = false;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(552, 64);
			this.txtPort.Name = "txtPort";
			this.txtPort.TabIndex = 68;
			this.txtPort.Text = "30000";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(464, 64);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 16);
			this.label10.TabIndex = 67;
			this.label10.Text = "License Port";
			// 
			// cmdLogOut
			// 
			this.cmdLogOut.Location = new System.Drawing.Point(576, 133);
			this.cmdLogOut.Name = "cmdLogOut";
			this.cmdLogOut.TabIndex = 66;
			this.cmdLogOut.Text = "Log Out";
			this.cmdLogOut.Click += new System.EventHandler(this.cmdLogOut_Click);
			// 
			// txtSessID
			// 
			this.txtSessID.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.txtSessID.Location = new System.Drawing.Point(110, 133);
			this.txtSessID.Name = "txtSessID";
			this.txtSessID.Size = new System.Drawing.Size(256, 20);
			this.txtSessID.TabIndex = 63;
			this.txtSessID.Text = "";
			// 
			// cmdLogInComp
			// 
			this.cmdLogInComp.Location = new System.Drawing.Point(14, 133);
			this.cmdLogInComp.Name = "cmdLogInComp";
			this.cmdLogInComp.TabIndex = 62;
			this.cmdLogInComp.Text = "Log In";
			this.cmdLogInComp.Click += new System.EventHandler(this.cmdLogInComp_Click);
			// 
			// txtLicenseServer
			// 
			this.txtLicenseServer.Location = new System.Drawing.Point(552, 40);
			this.txtLicenseServer.Name = "txtLicenseServer";
			this.txtLicenseServer.TabIndex = 61;
			this.txtLicenseServer.Text = "ILTLVH23";
			// 
			// Label9
			// 
			this.Label9.Location = new System.Drawing.Point(464, 40);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(80, 16);
			this.Label9.TabIndex = 60;
			this.Label9.Text = "License Server";
			// 
			// txtLanguage
			// 
			this.txtLanguage.Location = new System.Drawing.Point(552, 16);
			this.txtLanguage.Name = "txtLanguage";
			this.txtLanguage.TabIndex = 59;
			this.txtLanguage.Text = "ln_English";
			// 
			// Label8
			// 
			this.Label8.Location = new System.Drawing.Point(464, 16);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(80, 16);
			this.Label8.TabIndex = 58;
			this.Label8.Text = "Language";
			// 
			// txtCompanyPassword
			// 
			this.txtCompanyPassword.Location = new System.Drawing.Point(350, 85);
			this.txtCompanyPassword.Name = "txtCompanyPassword";
			this.txtCompanyPassword.TabIndex = 57;
			this.txtCompanyPassword.Text = "manager";
			// 
			// Label7
			// 
			this.Label7.Location = new System.Drawing.Point(238, 85);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(112, 24);
			this.Label7.TabIndex = 56;
			this.Label7.Text = "Company Password";
			// 
			// txtCompanyUserName
			// 
			this.txtCompanyUserName.Location = new System.Drawing.Point(350, 61);
			this.txtCompanyUserName.Name = "txtCompanyUserName";
			this.txtCompanyUserName.TabIndex = 55;
			this.txtCompanyUserName.Text = "manager";
			// 
			// Label6
			// 
			this.Label6.Location = new System.Drawing.Point(238, 61);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(112, 16);
			this.Label6.TabIndex = 54;
			this.Label6.Text = "Company UserName";
			// 
			// txtDataBasePassword
			// 
			this.txtDataBasePassword.Location = new System.Drawing.Point(350, 37);
			this.txtDataBasePassword.Name = "txtDataBasePassword";
			this.txtDataBasePassword.TabIndex = 53;
			this.txtDataBasePassword.Text = "";
			// 
			// Label5
			// 
			this.Label5.Location = new System.Drawing.Point(238, 37);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(112, 16);
			this.Label5.TabIndex = 52;
			this.Label5.Text = "DataBase Password";
			// 
			// txtDataBaseUserName
			// 
			this.txtDataBaseUserName.Location = new System.Drawing.Point(350, 13);
			this.txtDataBaseUserName.Name = "txtDataBaseUserName";
			this.txtDataBaseUserName.TabIndex = 51;
			this.txtDataBaseUserName.Text = "sa";
			// 
			// Label4
			// 
			this.Label4.Location = new System.Drawing.Point(238, 13);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(112, 16);
			this.Label4.TabIndex = 50;
			this.Label4.Text = "DataBase UserName";
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(14, 61);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(112, 16);
			this.Label3.TabIndex = 48;
			this.Label3.Text = "DataBase Type";
			// 
			// txtDataBaseName
			// 
			this.txtDataBaseName.Location = new System.Drawing.Point(126, 37);
			this.txtDataBaseName.Name = "txtDataBaseName";
			this.txtDataBaseName.TabIndex = 47;
			this.txtDataBaseName.Text = "SBODemo_US";
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(14, 37);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(112, 16);
			this.Label2.TabIndex = 46;
			this.Label2.Text = "DataBase Name";
			// 
			// txtDataBaseServer
			// 
			this.txtDataBaseServer.Location = new System.Drawing.Point(126, 13);
			this.txtDataBaseServer.Name = "txtDataBaseServer";
			this.txtDataBaseServer.TabIndex = 45;
			this.txtDataBaseServer.Text = "localhost";
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(14, 13);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(112, 16);
			this.Label1.TabIndex = 44;
			this.Label1.Text = "DataBase Server:";
			// 
			// txtDataBaseType
			// 
			this.txtDataBaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.txtDataBaseType.Items.AddRange(new object[] {
																 "dst_MSSQL",
																 "dst_DB_2",
																 "dst_SYBASE",
																 "dst_MSSQL2005",
																 "dst_MAXDB"});
			this.txtDataBaseType.Location = new System.Drawing.Point(128, 64);
			this.txtDataBaseType.Name = "txtDataBaseType";
			this.txtDataBaseType.Size = new System.Drawing.Size(104, 21);
			this.txtDataBaseType.TabIndex = 68;
			// 
			// SalesQuotationForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 469);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.txtItem2Quant);
			this.Controls.Add(this.Label16);
			this.Controls.Add(this.Label17);
			this.Controls.Add(this.txtItem2Code);
			this.Controls.Add(this.lblDoc);
			this.Controls.Add(this.txtDocNo);
			this.Controls.Add(this.txtUpQuantity);
			this.Controls.Add(this.Label14);
			this.Controls.Add(this.Label15);
			this.Controls.Add(this.txtUpItemCode);
			this.Controls.Add(this.txtItemQuantity);
			this.Controls.Add(this.Label13);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.txtItemCode);
			this.Controls.Add(this.txtBpCode);
			this.Controls.Add(this.txtUpdate);
			this.Controls.Add(this.cmdUpdate);
			this.Controls.Add(this.txtXml);
			this.Controls.Add(this.cmdAddQuotation);
			this.Name = "SalesQuotationForm";
			this.Text = "Sales Quotation";
			this.Load += new System.EventHandler(this.SalesQuotationForm_Load);
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		} 
        
        
        #endregion 
        
        public SalesQuotationClient.localhost1.DiServerServicesSample oWsSalesQuotation; 
        public string msSessionID; 
        public string msQuotationDocNum; 
        
        // The function Adds new Quotation with two items,
        // it builds the soap string using the Quotation template and
        // inserting the data into it
        private void cmdAddQuotation_Click( System.Object sender, System.EventArgs e ) { 
			try
			{
				System.Xml.XmlElement oQuotationXml = null; 
				System.Xml.XmlNodeList oBpCode = null; 
				System.Xml.XmlNode oItemCode = null; 
				System.Xml.XmlNode oFirstRow = null; 
				System.Xml.XmlNode oNewRow = null; 
				System.Xml.XmlNode oTaxCode = null; 
				System.Xml.XmlNode oItemQuantity = null; 
				System.Xml.XmlElement oXmlReply = null; 
				System.Xml.XmlNode oDocumentLines = null; 
            
				// get an empty Quotation - get the Quotation template 
				// for filling the items later
				oQuotationXml = ( ( System.Xml.XmlElement )( oWsSalesQuotation.GetEmptyQuotationXml( msSessionID ) ) ); 
            
				// get Bp ref
				oBpCode = oQuotationXml.SelectNodes( "//CardCode" ); 
				// adding Bp code -> bp that already exists
				oBpCode.Item( 0 ).InnerText = txtBpCode.Text; 
            
				//change document type
				oQuotationXml.SelectSingleNode("//Object").InnerText = "oQuotations";

				// add first item
            
				// get item ref
				oItemCode = oQuotationXml.SelectSingleNode( "//ItemCode" ); 
				// add item code,that already exists
				oItemCode.InnerText = txtItemCode.Text; 
            
				// get item ref
				oItemQuantity = oQuotationXml.SelectSingleNode( "//Quantity" ); 
				// Add item Quantity
				oItemQuantity.InnerText = txtItemQuantity.Text; 
            
				//add second item
            
				// get ref to the Document_Lines
				oDocumentLines = oQuotationXml.SelectSingleNode( "//Document_Lines" ); 
            
				// get the first row 
				oFirstRow = oDocumentLines.FirstChild; 
            
				// copy the first row the th new one -> for getting the same structure
				oNewRow = oFirstRow.CloneNode( true ); 
            
				// update the new row
				// get item ref
				oItemCode = oNewRow.SelectSingleNode( "//ItemCode" ); 
				// add item code
				oItemCode.InnerText = txtItem2Code.Text; 
            
				// get item Quantity ref
				oItemQuantity = oNewRow.SelectSingleNode( "//Quantity" ); 
				// Add item Quantity
				oItemQuantity.InnerText = txtItem2Quant.Text; 
            
				// add the new row to the DocumentLines object
				oDocumentLines.AppendChild( oNewRow ); 
            
				txtXml.Text = oQuotationXml.OuterXml; 
            
				// Change mouse cursor
				Cursor = System.Windows.Forms.Cursors.WaitCursor; 
            
				// Add Quotation
				oXmlReply = ( ( System.Xml.XmlElement )( oWsSalesQuotation.AddQuotation( txtSessID.Text, oQuotationXml.OuterXml ) ) ); 
            
				// Change mouse cursor
				Cursor = System.Windows.Forms.Cursors.Default; 
            
				string sRet = null; 
            
				// check for error
				if ( Strings.InStr( oXmlReply.InnerXml, "<env:Fault>", (Microsoft.VisualBasic.CompareMethod)(0) )>0 ) 
				{ // And (Not (sret.StartsWith("Error"))) Then
					sRet = "Error: " + oXmlReply.InnerXml; 
					Interaction.MsgBox( sRet, (Microsoft.VisualBasic.MsgBoxStyle)(0), null ); 
					return; 
				} 
            
				// saves the Quotation key
				msQuotationDocNum = oXmlReply.InnerText; 
            
				txtDocNo.Text = msQuotationDocNum; 
            
				Interaction.MsgBox( "Quotation Added , DocNum=" + msQuotationDocNum, (Microsoft.VisualBasic.MsgBoxStyle)(0), null ); 
            
				cmdUpdate.Enabled = true; 
            
			}
			catch ( Exception ex ) 
			{                 
				MessageBox.Show( ex.Message); 
			}             
        } 
        
        
        // The function updates an item in the Quotation ,
        // it builds the soap string without the template
        private void cmdUpdate_Click( System.Object sender, System.EventArgs e ) { 
			try
			{
            
				string sAddCmd = null; 
				string sItemCode = null; 
				string sQuantity = null; 
				System.Xml.XmlNode oXmlReply = null; 
				string sDocNum = null; 
				string sRet = null; 
            
            
				sItemCode = txtUpItemCode.Text; 
				sQuantity = txtUpQuantity.Text; 
				sDocNum = txtDocNo.Text; 
            
				// building the soap body without the template 
				// inserting oQuotations(enum), DocEntry(the Quotation key),
				// ItemCode & Item Quontity
				sAddCmd = @"<BOM xmlns="""">" + "<BO>" + "<AdmInfo>" + "<Object>oQuotations</Object>" + "</AdmInfo>" + "<QueryParams>" + "<DocEntry>" + sDocNum + "</DocEntry>" + "</QueryParams>" + "<Document_Lines>" + "<row>" + "<ItemCode>" + sItemCode + "</ItemCode>" + "<Quantity>" + sQuantity + "</Quantity>" + "</row>" + "</Document_Lines>" + "</BO>" + "</BOM>"; 
            
				// show sCmd in textbox
				txtUpdate.Text = sAddCmd; 
            
				// Change mouse cursor
				Cursor = System.Windows.Forms.Cursors.WaitCursor; 
            
				// update quotation & return result - the quotation key
				oXmlReply = oWsSalesQuotation.UpdateQuotation( txtSessID.Text, sAddCmd ); 
            
				// Change mouse cursor
				Cursor = System.Windows.Forms.Cursors.Default; 
            
				// check for error
				if ( Strings.InStr( oXmlReply.InnerXml, "<env:Fault>", (Microsoft.VisualBasic.CompareMethod)(0) ) >0) 
				{ // And (Not (sret.StartsWith("Error"))) Then
					sRet = "Error: " + oXmlReply.InnerXml; 
					Interaction.MsgBox( sRet, (Microsoft.VisualBasic.MsgBoxStyle)(0), null ); 
					return; 
				} 
            
				Interaction.MsgBox( "Quotation " + oXmlReply.InnerText + " was updated", (Microsoft.VisualBasic.MsgBoxStyle)(0), null ); 

			}
			catch ( Exception ex ) 
			{                 
				MessageBox.Show( ex.Message); 
			}                                     
        } 
        
        
        // LogIn to company
        private void cmdLogInComp_Click( System.Object sender, System.EventArgs e ) { 
            
            // Change mouse cursor
            Cursor = System.Windows.Forms.Cursors.WaitCursor; 
            
            // create new DiServerServicesSample object
            oWsSalesQuotation = new SalesQuotationClient.localhost1.DiServerServicesSample(); 
            
            // log in to company
            msSessionID = oWsSalesQuotation.Login (txtDataBaseServer.Text, txtDataBaseName.Text, txtDataBaseType.Text, txtDataBaseUserName.Text, txtDataBasePassword.Text, txtCompanyUserName.Text, txtCompanyPassword.Text, txtLanguage.Text, txtLicenseServer.Text,txtPort.Text); 
            
            // Change mouse cursor
            Cursor = System.Windows.Forms.Cursors.Default; 
            
            txtSessID.Text = msSessionID; 
            
            cmdAddQuotation.Enabled = true; 
            
        } 
        
        
        // LogOut from company
        private void cmdLogOut_Click( System.Object sender, System.EventArgs e ) { 
            
            string sResult = null; 
            
            // create di-server-sample object
            oWsSalesQuotation = new SalesQuotationClient.localhost1.DiServerServicesSample(); 
            
            // Change mouse cursor
            Cursor = System.Windows.Forms.Cursors.WaitCursor; 
            
            // log out
            sResult = System.Convert.ToString( oWsSalesQuotation.LogOut( msSessionID ) ); 
            
            // Change mouse cursor
            Cursor = System.Windows.Forms.Cursors.Default; // Change mouse cursor
            
            // check for error
            if ( Strings.InStr( sResult, "<env:Fault>", (Microsoft.VisualBasic.CompareMethod)(0) )>0 ) { // And (Not (sret.StartsWith("Error"))) Then
                sResult = "Error: " + sResult; 
                Interaction.MsgBox( sResult, (Microsoft.VisualBasic.MsgBoxStyle)(0), null ); 
                return; 
            } 
            else { 
                Interaction.MsgBox( "Logged Out", (Microsoft.VisualBasic.MsgBoxStyle)(0), null ); 
            } 
            
            cmdAddQuotation.Enabled = false; 
            cmdUpdate.Enabled = false; 
            cmdLogInComp.Enabled = true; 
            
        } 
        
        
        private void SalesQuotationForm_Load( System.Object sender, System.EventArgs e ) { 
            txtDataBaseType.Text = "dst_MSSQL2005";
            // initiate command buttons
            cmdAddQuotation.Enabled = false; 
            cmdUpdate.Enabled = false; 
            
        } 
        
        
        
        [STAThread]
        public static void Main() { Application.Run( new SalesQuotationForm() ); }
    } 
} 
