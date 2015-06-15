using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
namespace WSClient {
    public class frmMain : System.Windows.Forms.Form { 
        
        #region ' Windows Form Designer generated code ' 
        
        public frmMain() : base() { 
            
            
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
        internal System.Windows.Forms.Button cmdGetBPList; 
        internal System.Windows.Forms.ListBox lstBP; 
        internal System.Windows.Forms.Label Label1; 
        internal System.Windows.Forms.Label Label2; 
        internal System.Windows.Forms.Label Label3; 
        internal System.Windows.Forms.Label Label4; 
        internal System.Windows.Forms.Label Label5; 
        internal System.Windows.Forms.Label Label6; 
        internal System.Windows.Forms.Label Label7; 
        internal System.Windows.Forms.Label Label8; 
        internal System.Windows.Forms.Label Label9; 
        internal System.Windows.Forms.TextBox txtDataBaseServer; 
        internal System.Windows.Forms.TextBox txtDataBaseName; 
        internal System.Windows.Forms.TextBox txtDataBaseUserName; 
        internal System.Windows.Forms.TextBox txtDataBasePassword; 
        internal System.Windows.Forms.TextBox txtCompanyUserName; 
        internal System.Windows.Forms.TextBox txtCompanyPassword; 
        internal System.Windows.Forms.TextBox txtLanguage; 
        internal System.Windows.Forms.TextBox txtLicenseServer; 
        internal System.Windows.Forms.Button cmdLogIn; 
        internal System.Windows.Forms.TextBox txtSessID; 
        internal System.Windows.Forms.Button cmdAddBP; 
        internal System.Windows.Forms.TextBox txtBPName; 
        internal System.Windows.Forms.TextBox txtBPCode; 
        internal System.Windows.Forms.Label Label10; 
        internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.TextBox txtPort;
		internal System.Windows.Forms.Label label12;
		internal System.Windows.Forms.ComboBox txtDataBaseType; 
        internal System.Windows.Forms.TextBox txtTmp; 
        [ System.Diagnostics.DebuggerStepThrough() ]
        private void InitializeComponent() { 
			this.cmdGetBPList = new System.Windows.Forms.Button();
			this.lstBP = new System.Windows.Forms.ListBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtDataBaseServer = new System.Windows.Forms.TextBox();
			this.txtDataBaseName = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtDataBaseUserName = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtDataBasePassword = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtCompanyUserName = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtCompanyPassword = new System.Windows.Forms.TextBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.txtLanguage = new System.Windows.Forms.TextBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.txtLicenseServer = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.cmdLogIn = new System.Windows.Forms.Button();
			this.txtSessID = new System.Windows.Forms.TextBox();
			this.txtBPName = new System.Windows.Forms.TextBox();
			this.cmdAddBP = new System.Windows.Forms.Button();
			this.txtBPCode = new System.Windows.Forms.TextBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.txtTmp = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtDataBaseType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// cmdGetBPList
			// 
			this.cmdGetBPList.Location = new System.Drawing.Point(8, 192);
			this.cmdGetBPList.Name = "cmdGetBPList";
			this.cmdGetBPList.TabIndex = 0;
			this.cmdGetBPList.Text = "Get BP List";
			this.cmdGetBPList.Click += new System.EventHandler(this.cmdGetBPList_Click);
			// 
			// lstBP
			// 
			this.lstBP.HorizontalScrollbar = true;
			this.lstBP.Location = new System.Drawing.Point(96, 192);
			this.lstBP.Name = "lstBP";
			this.lstBP.Size = new System.Drawing.Size(120, 160);
			this.lstBP.TabIndex = 1;
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(8, 8);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(112, 16);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "DataBase Server:";
			// 
			// txtDataBaseServer
			// 
			this.txtDataBaseServer.Location = new System.Drawing.Point(128, 8);
			this.txtDataBaseServer.Name = "txtDataBaseServer";
			this.txtDataBaseServer.TabIndex = 3;
			this.txtDataBaseServer.Text = "localhost";
			// 
			// txtDataBaseName
			// 
			this.txtDataBaseName.Location = new System.Drawing.Point(128, 32);
			this.txtDataBaseName.Name = "txtDataBaseName";
			this.txtDataBaseName.TabIndex = 5;
			this.txtDataBaseName.Text = "SBODemo_US";
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(8, 32);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(112, 16);
			this.Label2.TabIndex = 4;
			this.Label2.Text = "DataBase Name";
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(8, 56);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(112, 16);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "DataBase Type";
			// 
			// txtDataBaseUserName
			// 
			this.txtDataBaseUserName.Location = new System.Drawing.Point(128, 80);
			this.txtDataBaseUserName.Name = "txtDataBaseUserName";
			this.txtDataBaseUserName.TabIndex = 9;
			this.txtDataBaseUserName.Text = "sa";
			// 
			// Label4
			// 
			this.Label4.Location = new System.Drawing.Point(8, 80);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(112, 16);
			this.Label4.TabIndex = 8;
			this.Label4.Text = "DataBase UserName";
			// 
			// txtDataBasePassword
			// 
			this.txtDataBasePassword.Location = new System.Drawing.Point(128, 104);
			this.txtDataBasePassword.Name = "txtDataBasePassword";
			this.txtDataBasePassword.TabIndex = 11;
			this.txtDataBasePassword.Text = "";
			// 
			// Label5
			// 
			this.Label5.Location = new System.Drawing.Point(8, 104);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(112, 16);
			this.Label5.TabIndex = 10;
			this.Label5.Text = "DataBase Password";
			// 
			// txtCompanyUserName
			// 
			this.txtCompanyUserName.Location = new System.Drawing.Point(352, 8);
			this.txtCompanyUserName.Name = "txtCompanyUserName";
			this.txtCompanyUserName.TabIndex = 13;
			this.txtCompanyUserName.Text = "manager";
			// 
			// Label6
			// 
			this.Label6.Location = new System.Drawing.Point(240, 8);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(112, 16);
			this.Label6.TabIndex = 12;
			this.Label6.Text = "Company UserName";
			// 
			// txtCompanyPassword
			// 
			this.txtCompanyPassword.Location = new System.Drawing.Point(352, 32);
			this.txtCompanyPassword.Name = "txtCompanyPassword";
			this.txtCompanyPassword.TabIndex = 15;
			this.txtCompanyPassword.Text = "manager";
			// 
			// Label7
			// 
			this.Label7.Location = new System.Drawing.Point(240, 32);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(112, 16);
			this.Label7.TabIndex = 14;
			this.Label7.Text = "Company Password";
			// 
			// txtLanguage
			// 
			this.txtLanguage.Location = new System.Drawing.Point(352, 56);
			this.txtLanguage.Name = "txtLanguage";
			this.txtLanguage.TabIndex = 17;
			this.txtLanguage.Text = "ln_English";
			// 
			// Label8
			// 
			this.Label8.Location = new System.Drawing.Point(240, 56);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(112, 16);
			this.Label8.TabIndex = 16;
			this.Label8.Text = "Language";
			// 
			// txtLicenseServer
			// 
			this.txtLicenseServer.Location = new System.Drawing.Point(352, 80);
			this.txtLicenseServer.Name = "txtLicenseServer";
			this.txtLicenseServer.TabIndex = 19;
			this.txtLicenseServer.Text = "localhost";
			// 
			// Label9
			// 
			this.Label9.Location = new System.Drawing.Point(240, 80);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(112, 16);
			this.Label9.TabIndex = 18;
			this.Label9.Text = "License Server";
			// 
			// cmdLogIn
			// 
			this.cmdLogIn.Location = new System.Drawing.Point(8, 144);
			this.cmdLogIn.Name = "cmdLogIn";
			this.cmdLogIn.TabIndex = 20;
			this.cmdLogIn.Text = "Log In";
			this.cmdLogIn.Click += new System.EventHandler(this.cmdLogIn_Click);
			// 
			// txtSessID
			// 
			this.txtSessID.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.txtSessID.Location = new System.Drawing.Point(96, 144);
			this.txtSessID.Name = "txtSessID";
			this.txtSessID.ReadOnly = true;
			this.txtSessID.Size = new System.Drawing.Size(264, 20);
			this.txtSessID.TabIndex = 21;
			this.txtSessID.Text = "";
			// 
			// txtBPName
			// 
			this.txtBPName.Location = new System.Drawing.Point(296, 184);
			this.txtBPName.Name = "txtBPName";
			this.txtBPName.Size = new System.Drawing.Size(120, 20);
			this.txtBPName.TabIndex = 22;
			this.txtBPName.Text = "";
			// 
			// cmdAddBP
			// 
			this.cmdAddBP.Location = new System.Drawing.Point(432, 184);
			this.cmdAddBP.Name = "cmdAddBP";
			this.cmdAddBP.TabIndex = 23;
			this.cmdAddBP.Text = "Add BP";
			this.cmdAddBP.Click += new System.EventHandler(this.cmdAddBP_Click);
			// 
			// txtBPCode
			// 
			this.txtBPCode.Location = new System.Drawing.Point(296, 216);
			this.txtBPCode.Name = "txtBPCode";
			this.txtBPCode.Size = new System.Drawing.Size(120, 20);
			this.txtBPCode.TabIndex = 24;
			this.txtBPCode.Text = "";
			// 
			// Label10
			// 
			this.Label10.Location = new System.Drawing.Point(232, 184);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(56, 16);
			this.Label10.TabIndex = 25;
			this.Label10.Text = "BP Name";
			// 
			// Label11
			// 
			this.Label11.Location = new System.Drawing.Point(232, 216);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(56, 16);
			this.Label11.TabIndex = 26;
			this.Label11.Text = "BP Code";
			// 
			// txtTmp
			// 
			this.txtTmp.Location = new System.Drawing.Point(240, 256);
			this.txtTmp.Multiline = true;
			this.txtTmp.Name = "txtTmp";
			this.txtTmp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtTmp.Size = new System.Drawing.Size(264, 96);
			this.txtTmp.TabIndex = 27;
			this.txtTmp.Text = "";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(352, 104);
			this.txtPort.Name = "txtPort";
			this.txtPort.TabIndex = 29;
			this.txtPort.Text = "30000";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(240, 104);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 16);
			this.label12.TabIndex = 28;
			this.label12.Text = "Port";
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
			this.txtDataBaseType.Location = new System.Drawing.Point(128, 56);
			this.txtDataBaseType.Name = "txtDataBaseType";
			this.txtDataBaseType.Size = new System.Drawing.Size(104, 21);
			this.txtDataBaseType.TabIndex = 69;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 365);
			this.Controls.Add(this.txtDataBaseType);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtTmp);
			this.Controls.Add(this.txtBPCode);
			this.Controls.Add(this.txtBPName);
			this.Controls.Add(this.txtSessID);
			this.Controls.Add(this.txtLicenseServer);
			this.Controls.Add(this.txtLanguage);
			this.Controls.Add(this.txtCompanyPassword);
			this.Controls.Add(this.txtCompanyUserName);
			this.Controls.Add(this.txtDataBasePassword);
			this.Controls.Add(this.txtDataBaseUserName);
			this.Controls.Add(this.txtDataBaseName);
			this.Controls.Add(this.txtDataBaseServer);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.Label10);
			this.Controls.Add(this.cmdAddBP);
			this.Controls.Add(this.cmdLogIn);
			this.Controls.Add(this.Label9);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lstBP);
			this.Controls.Add(this.cmdGetBPList);
			this.Name = "frmMain";
			this.Text = "Web Service Client";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);

		} 
        
        
        #endregion 
        
        public WSClient.localhost1.Sample DIS; 
        public string SessionID; 
        
        private void cmdLogIn_Click( System.Object sender, System.EventArgs e ) { 
            DIS = new WSClient.localhost1.Sample(); 
            SessionID = DIS.Login( txtDataBaseServer.Text, txtDataBaseName.Text, txtDataBaseType.Text, txtDataBaseUserName.Text, txtDataBasePassword.Text, txtCompanyUserName.Text, txtCompanyPassword.Text, txtLanguage.Text, txtLicenseServer.Text ,txtPort.Text); 
            txtSessID.Text = SessionID; 
        } 
        
        
        private void cmdGetBPList_Click( System.Object sender, System.EventArgs e ) { 
            System.Xml.XmlElement xmlE = null; 
            System.Xml.XmlNodeList bpName = null; 
			 System.Xml.XmlNodeList bpCode = null; 
            
            xmlE = ( ( System.Xml.XmlElement )( DIS.GetBPList( SessionID, "" ) ) ); 
            bpName = xmlE.SelectNodes( "//CardName" ); 
			bpCode = xmlE.SelectNodes( "//CardCode" ); 
            
			lstBP.Items.Clear();
            int i = 0; 
            for ( i=0; i<=bpName.Count - 1; i++ ) { 
                lstBP.Items.Add( bpName.Item( i ).InnerText + "  " + bpName.Item( i ).InnerText ); 
            } 
        } 
        
        
        private void cmdAddBP_Click( System.Object sender, System.EventArgs e ) { 
            System.Xml.XmlElement xmlE = null; 
            System.Xml.XmlNodeList bpCode = null; 
            System.Xml.XmlNode bpName = null; 
            
            
            xmlE = ( ( System.Xml.XmlElement )( DIS.GetEmptyBPXml( SessionID ) ) ); 
            
            bpCode = xmlE.SelectNodes( "//CardCode" ); 
            bpName = xmlE.SelectSingleNode( "//CardName" ); 
            bpCode.Item( 0 ).InnerText = txtBPCode.Text; 
            bpCode.Item( 1 ).InnerText = txtBPCode.Text; 
            bpName.InnerText = txtBPName.Text; 
            
            txtTmp.Text = xmlE.OuterXml; 
            
            DIS.AddBP( SessionID, xmlE.OuterXml ); 
        } 
        
        
        [STAThread]
        public static void Main() { Application.Run( new frmMain() ); }

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			txtDataBaseType.Text = "dst_MSSQL2005";
		}
    } 
    
    
} 
