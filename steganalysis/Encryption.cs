using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace imgefile

{
    public partial class Encryption : Form
    {
        public Encryption()
        {
            InitializeComponent();
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
                //   outputpath.Text = Path.GetExtension(fdlg.FileName); 
                outputpath.Text = Path.GetDirectoryName(fdlg.FileName);
            }
        }

        private void img_bt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";
            openfile.Multiselect = false;
            openfile.ShowDialog();
            if (!String.IsNullOrEmpty(openfile.FileName))
            {
                pictureBox1.BackgroundImage = Image.FromFile(openfile.FileName);
            }
        }

        private void Encryption_bt_Click(object sender, EventArgs e)
        {


            string embtext = pw_tx.Text;
            //  string password = @"myKey123"; // Your Key Here
            string password = pw_tx.Text; // Your Key Here

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
            string outpath = Path.GetDirectoryName(filepath.Text) + Guid.NewGuid().ToString()+Path.GetExtension(filepath.Text);
            //   outputpath.Text = Path.GetExtension(fdlg.FileName); 
            // outputpath.Text = Path.GetDirectoryName(fdlg.FileName);
            string cryptFile = outpath;
            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateEncryptor(key, key),
                CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(filepath.Text, FileMode.Open);

            int data;
            while ((data = fsIn.ReadByte()) != -1)
                cs.WriteByte((byte)data);
            fsIn.Close();
            cs.Close();
            fsCrypt.Close();
            File.Delete(filepath.Text);
            File.Move(outpath, filepath.Text);
            Bitmap img = (Bitmap)pictureBox1.BackgroundImage;
            string Steg_pw = "123";
            if (string.IsNullOrEmpty(embtext))
            {
                MessageBox.Show("Empty string can't be hidden", "Warning");
                return;
            }
            if (string.IsNullOrEmpty(Steg_pw))
            {
                MessageBox.Show("Password can't be empty", "Warning");
                return;
            }

            try
            {
                embtext = RijndaelAlgo.Encrypt(embtext, Steg_pw);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                img = SteganographyHelper.MergeText(embtext, img);
            string filename = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".png";

            string img_location = "F:\\img\\" + filename;
            img.Save(img_location, ImageFormat.Png);
            string code = "http://localhost" + "/" + filename;

           
            QRCodeEncoder enc = new QRCodeEncoder();
            Bitmap bitMap = enc.Encode(code);
            pictureBox2.BackgroundImage = bitMap as Image;
            SaveFileDialog sav = new SaveFileDialog();
                sav.Filter = "Png Image|*.png|Bitmap Image|*.bmp";

                if (sav.ShowDialog() == DialogResult.OK)
                {
                    switch (sav.FilterIndex)
                    {
                        case 0:
                            {
                            bitMap.Save(sav.FileName, ImageFormat.Png);
                            }
                            break;
                        case 1:
                            {
                            bitMap.Save(sav.FileName, ImageFormat.Bmp);
                            }
                            break;
                    }
                }
               
            MessageBox.Show("File Encrypted successfully", "Information");
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encryption failed! "+ex.Message , "Error");
            }
        }
        private void pw_tx_TextChanged(object sender, EventArgs e)
        {

        }
       



    }
}

