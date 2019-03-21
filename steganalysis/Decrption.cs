using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Net;
using System.IO;
using System.Security.Cryptography;
namespace imgefile
{
    public partial class q2 : Form
    {
        public q2()
        {
            InitializeComponent();
        }

        private void img_bt_Click(object sender, EventArgs e)
        {
            if(System.IO.File.Exists(filepath.Text))
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";
                openfile.Multiselect = false;
                openfile.ShowDialog();
                if (!String.IsNullOrEmpty(openfile.FileName))
                {
                    qrimg.BackgroundImage = Image.FromFile(openfile.FileName);
                }
            }
            else
            {
                MessageBox.Show("Kindly select encrypted File");
            }
            
        }

        private void get_image_from_qr_Click(object sender, EventArgs e)
        {
            if(qrimg.BackgroundImage != null)
            {
                this.get_ulr_from_qr();
            }
            else
            {
                MessageBox.Show("Kindly select QR Code To get ULR");
            }
           
        }
        protected void get_ulr_from_qr()
        {
            QRCodeDecoder dec = new QRCodeDecoder();
            URL_tx.Text = (dec.decode(new QRCodeBitmapImage(qrimg.BackgroundImage as Bitmap)));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (URL_tx.Text != "")
            {
                this.load_image_from_url(URL_tx.Text);
            }
            else
            {
                MessageBox.Show("URL is Empty");
            }
               
        }
        protected void load_image_from_url(string url)
        {
            var request = WebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                ulr_image.BackgroundImage = Bitmap.FromStream(stream);
            }
        }

        private void Decryption_bt_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap img = (Bitmap)ulr_image.BackgroundImage;
            string Steg_pw = "123";
           
            string extractString = SteganographyHelper.ExtractText(img);
            if (string.IsNullOrEmpty(Steg_pw))
            {
                MessageBox.Show("Please specify the password, To Extract the information.", "Security");
                return;
            }

                extractString = RijndaelAlgo.Decrypt(extractString, Steg_pw);   
                string inputFile = filepath.Text;
                string outpath = Path.GetDirectoryName(filepath.Text) + Guid.NewGuid().ToString() + Path.GetExtension(filepath.Text);
                string outputFile = outpath;
                string password = extractString; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
                File.Delete(filepath.Text);
                File.Move(outpath, filepath.Text);
                MessageBox.Show("File Decrypted successfully", "Information");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Decryption failed!  " + ex.Message, "Error");
                return;
            }
        }

        private void openfilebt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                filepath.Text = fdlg.FileName;
            }
        }
    }
   
}
