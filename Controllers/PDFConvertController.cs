using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PDFA3BWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class PDFConvertController : ControllerBase
    {
        private async Task<byte[]> ConvertPDF(IFormFile _pdfFile,IFormFile _xmlFile,PdfType _pdfType)
        {
            try
            {
                byte[] pdfBytes = null, xmlBytes = null;
                using (MemoryStream pdfStream = new MemoryStream())
                {
                    _pdfFile.CopyTo(pdfStream);
                    if (pdfStream != null)
                    {
                        MemoryStream xmlStream = new MemoryStream();
                        _xmlFile.CopyTo(xmlStream);
                        xmlBytes= xmlStream.ToArray();
                    }

                    pdfBytes = ConvertPDFObj.ConvertPDF2PDFA3B(pdfStream, xmlBytes, _xmlFile.FileName, _pdfType);
                }
                return pdfBytes;

            }
            catch (Exception ex)
            {

                return null;
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> ConvertPDFA1A(IFormFile pdfFile,IFormFile xmlFile)
        {
            try
            {
                byte[] pdfByte = await ConvertPDF(pdfFile, xmlFile, PdfType.PDFA1A);
                if (pdfByte != null)
                    return File(pdfByte, "application/pdf");
                else 
                    return null;
                
            }
            catch (Exception ex)
            {

                return Ok(HttpStatusCode.NotFound + ex.ToString()) ;
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConvertPDFA1B(IFormFile pdfFile, IFormFile xmlFile)
        {
            try
            {
                byte[] pdfByte = await ConvertPDF(pdfFile, xmlFile, PdfType.PDFA1B);
                if (pdfByte != null)
                    return File(pdfByte, "application/pdf");
                else
                    return null;

            }
            catch (Exception ex)
            {

                return Ok(HttpStatusCode.NotFound + ex.ToString());
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConvertPDFA2A(IFormFile pdfFile, IFormFile xmlFile)
        {
            try
            {
                byte[] pdfByte = await ConvertPDF(pdfFile, xmlFile, PdfType.PDFA2A);
                if (pdfByte != null)
                    return File(pdfByte, "application/pdf");
                else
                    return null;

            }
            catch (Exception ex)
            {

                return Ok(HttpStatusCode.NotFound + ex.ToString());
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConvertPDFA2B(IFormFile pdfFile, IFormFile xmlFile)
        {
            try
            {
                byte[] pdfByte = await ConvertPDF(pdfFile, xmlFile, PdfType.PDFA2B);
                if (pdfByte != null)
                    return File(pdfByte, "application/pdf");
                else
                    return null;

            }
            catch (Exception ex)
            {

                return Ok(HttpStatusCode.NotFound + ex.ToString());
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConvertPDFA3A(IFormFile pdfFile, IFormFile xmlFile)
        {
            try
            {
                byte[] pdfByte = await ConvertPDF(pdfFile, xmlFile, PdfType.PDFA3A);
                if (pdfByte != null)
                    return File(pdfByte, "application/pdf");
                else
                    return null;

            }
            catch (Exception ex)
            {

                return Ok(HttpStatusCode.NotFound + ex.ToString());
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConvertPDFA3B(IFormFile pdfFile, IFormFile xmlFile)
        {
            try
            {
                byte[] pdfByte = await ConvertPDF(pdfFile, xmlFile, PdfType.PDFA3B);
                if (pdfByte != null)
                    return File(pdfByte, "application/pdf");
                else
                    return null;

            }
            catch (Exception ex)
            {

                return Ok(HttpStatusCode.NotFound + ex.ToString());
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConvertPDFX1A2001(IFormFile pdfFile, IFormFile xmlFile)
        {
            try
            {
                byte[] pdfByte = await ConvertPDF(pdfFile, xmlFile, PdfType.PDFX1A2001);
                if (pdfByte != null)
                    return File(pdfByte, "application/pdf");
                else
                    return Ok("No Method Found");

            }
            catch (Exception ex)
            {

                return Ok(HttpStatusCode.NotFound + ex.ToString());
            }
        }
         
    }
}
