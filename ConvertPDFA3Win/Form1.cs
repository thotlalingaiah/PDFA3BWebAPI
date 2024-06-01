using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConvertPDFA3Win
{
    public partial class Form1 : Form
    {
        public string BaseUrl = @"https://e-pdf.mylstech.com/api/";
        int pdfType = 0;
        string convertType = "";
        public Form1()
        {
            InitializeComponent();
        }
        private string GetSelectedPdfType()
        {
            RadioButton radioButton = new RadioButton();
            if (radioButton1.Checked) pdfType = 0;
            if (radioButton2.Checked) pdfType = 1;
            if (radioButton3.Checked) pdfType = 2;
            if (radioButton4.Checked) pdfType = 3;
            if (radioButton5.Checked) pdfType = 4;
            if (radioButton6.Checked) pdfType = 5;
            if (radioButton7.Checked) pdfType = 6;


           
            switch (pdfType)
            {
                case 0:
                    convertType = "ConvertPDFA1A";
                    break;
                case 1:
                    convertType = "ConvertPDFA2A";
                    break;
                case 2:
                    convertType = "ConvertPDFA3A";
                    break;
                case 3:
                    convertType = "ConvertPDFA1B";
                    break;
                case 4:
                    convertType = "ConvertPDFA2B";
                    break;
                case 5:
                    convertType = "ConvertPDFA3B";
                    break;
                case 6:
                    convertType = "ConvertPDFX1A2001";
                                   
                    break;
                default:
                    convertType = "";
                    break;

            }
            return convertType;
        }
        private async void btnConvert_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            
            convertType = GetSelectedPdfType();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent (System.IO.File.OpenRead(txtPDF.Text)), "pdfFile", txtPDF.Text);
                content.Add(new StreamContent (System.IO.File.OpenRead(txtXML.Text)), "xmlFile", txtXML.Text);

                ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
                HttpResponseMessage response = await client.PostAsync("PDFConvert/" + convertType, content);
                response.EnsureSuccessStatusCode();
                var contentType = response.Content.Headers.GetValues("Content-Type").First();
                if(contentType.Contains("text/plain"))
                {
                    string responseStr = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(responseStr);
                    return;
                }
                byte[] responseData = await response.Content.ReadAsByteArrayAsync();
                System.IO.File.WriteAllBytes( System.IO.Path.Combine(txtSavePath.Text, "response_" + convertType +"_"+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf"), responseData);
            }
            progressBar1.Visible = false;
        }
         
    }
}
