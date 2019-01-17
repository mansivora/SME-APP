using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API_App.Models;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace API_App.Controllers
{
    public class HomeController : Controller
    {
        Function fn = new Function();
        string apikey = System.Configuration.ConfigurationManager.AppSettings["apikey"];
        string Getrequestendpoint = System.Configuration.ConfigurationManager.AppSettings["requestendpoint"];
        string requestendpoint = "";
        public ActionResult Index()
        {
            APIModel _objModel = new APIModel();
            try
            {
              
            }
            catch (Exception ex)
            {
                storeError(ex);
            }
            FillCustomerTypeCombo(); FillCountryCombo();
            FillCurrencyCombo(); FillDesignationCombo();
            FillCompanyTypeCombo();
            return View(_objModel);
        }

        [HttpPost]
        public ActionResult Index(APIModel _objModel, HttpPostedFileBase TradeLicUpd)
        {
            try
            {
                string authorisation = token();

                // POST METHODE
                requestendpoint = "";
                requestendpoint = Getrequestendpoint + "Customer/MasterAdd";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestendpoint);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("authorization", authorisation);
                httpWebRequest.Headers.Add("Cache-Control", "no-cache");
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        name = _objModel.CompanyName,
                        customertypeid = _objModel.customertypeid,
                        companytypeid = _objModel.CompanyTypeID,
                        othercompanytype = _objModel.OtherCompanyTypeName,
                        licno = _objModel.TradeLicenceNo,
                        licexpdate = _objModel.LicenceExpDate,
                        licauth = _objModel.AuthCountry,
                        inccountryid = _objModel.IncCountryID,
                        incdate = _objModel.IncDate,
                        busactivity = _objModel.BusinessActivity,
                        telno = _objModel.TelNo,
                        website = _objModel.Website,
                        currencyid = _objModel.CurrencyID,
                        annturnover = _objModel.AnnTurnover,
                        noofemp = _objModel.NoEmp,
                        firstname = _objModel.FirstName,
                        lastname = _objModel.LastName,
                        mobileno = _objModel.MobileNo,
                        designationid = _objModel.DesignationID,
                        otherdesignation = _objModel.OtherDesignationName,
                        emailid = _objModel.EmailID
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var jsonString = JObject.Parse(result);
                    int Id = Convert.ToInt32(jsonString["Id"].ToString());
                    //if (Id > 0 && TradeLicUpd.FileName != null)
                    //{
                    //    //UploadImages(Id, TradeLicUpd);
                    //}
                    return RedirectToAction("BuyerReg", "Home", new { Id = Id });
                }
            }
            catch (Exception ex)
            {
                storeError(ex);
            }
            FillCustomerTypeCombo(); FillCountryCombo();
            FillCurrencyCombo(); FillDesignationCombo();
            FillCompanyTypeCombo();
            return View(_objModel);
        }

        public ActionResult BuyerReg(int Id)
        {
            APIModel _objModel = new APIModel();
            try
            {
               
            _objModel.tempcustomerid = Id;
          
            }
            catch (Exception ex)
            {
                storeError(ex);
            }
            FillCustomerTypeCombo(); FillCountryCombo();
            FillCurrencyCombo(); FillDesignationCombo();
            FillCompanyTypeCombo(); FillIndustryCombo();
            return View(_objModel);
        }

        [HttpPost]
        public ActionResult BuyerReg(APIModel _objModel)
        {
            try
            {
                string authorisation = token();

                // POST METHODE
                requestendpoint = "";
                requestendpoint = Getrequestendpoint + "Customer/DetailsAdd";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestendpoint);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("authorization", authorisation);
                httpWebRequest.Headers.Add("Cache-Control", "no-cache");
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        tempcustomerid = _objModel.tempcustomerid,
                        name = _objModel.Name,
                        countryid = _objModel.CountryID,
                        website = _objModel.Website,
                        industryid = _objModel.IndustryID,
                        otherindustry = _objModel.OtherIndustryName,
                        project = "project",
                        currencyid = _objModel.CurrencyID,
                        annsales = _objModel.AnnTurnover,
                        commterms = _objModel.CommTerms,
                        othercommterms = _objModel.OtherCommTerms,
                        firstname = _objModel.FirstName,
                        lastname = _objModel.CommTerms,
                        designationid = _objModel.DesignationID,
                        otherdesignation = _objModel.OtherDesignationName,
                        mobileno = _objModel.MobileNo,
                        emailid = _objModel.EmailID
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var jsonString = JObject.Parse(result);
                    //int Id = Convert.ToInt32(jsonString["Id"].ToString());
                  
                    return RedirectToAction("SelfDecl", "Home", new { Id = _objModel.tempcustomerid });
                }
            }
            catch (Exception ex)
            {
                storeError(ex);
            }
            FillCustomerTypeCombo(); FillCountryCombo();
            FillCurrencyCombo(); FillDesignationCombo();
            FillCompanyTypeCombo(); FillIndustryCombo();
            return View(_objModel);
        }

        public ActionResult SelfDecl(int Id, bool IsReturn = false)
        {
            try
            {
               
             
            }
            catch (Exception ex)
            {
                storeError(ex);
            }
            return View();
        }
        [HttpPost]
        public ActionResult SelfDecl(APIModel _objModel, FormCollection frm)
        {
            return View(_objModel);
        }
     
        public void FillCustomerTypeCombo()
        {
            string authorisation = token();

            requestendpoint = "";
            requestendpoint = Getrequestendpoint + "Common/CustomerTypeList/0";

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(requestendpoint);
            WebReq.Method = "GET";
            WebReq.Headers.Add("authorization", authorisation);
            WebReq.Headers.Add("Cache-Control", "no-cache");

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string jsontxt = _Answer.ReadToEnd();

            var DDLCustomerTypeData = JsonConvert.DeserializeObject<List<Models.APIModel>>(jsontxt);
            if (DDLCustomerTypeData != null && DDLCustomerTypeData.Count > 0)
                ViewBag.DDLCustomerTypeID = DDLCustomerTypeData;
            else
                ViewBag.DDLCustomerTypeID = new List<SelectListItem> { };
        }

        public void FillCompanyTypeCombo()
        {
            string authorisation = token();

            requestendpoint = "";
            requestendpoint = Getrequestendpoint + "Common/CompanyTypeList/0";

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(requestendpoint);
            WebReq.Method = "GET";
            WebReq.Headers.Add("authorization", authorisation);
            WebReq.Headers.Add("Cache-Control", "no-cache");

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string jsontxt = _Answer.ReadToEnd();

            var DDLCompanyTypeData = JsonConvert.DeserializeObject<List<Models.APIModel>>(jsontxt);
            if (DDLCompanyTypeData != null && DDLCompanyTypeData.Count > 0)
                ViewBag.DDLCompanyTypeID = DDLCompanyTypeData;
            else
                ViewBag.DDLCompanyTypeID = new List<SelectListItem> { };
        }

        public void FillCurrencyCombo()
        {
            string authorisation = token();

            requestendpoint = "";
            requestendpoint = Getrequestendpoint + "Common/CurrencyList/0";

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(requestendpoint);
            WebReq.Method = "GET";
            WebReq.Headers.Add("authorization", authorisation);
            WebReq.Headers.Add("Cache-Control", "no-cache");

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string jsontxt = _Answer.ReadToEnd();

            var DDLCurrencyData = JsonConvert.DeserializeObject<List<Models.APIModel>>(jsontxt);
            if (DDLCurrencyData != null && DDLCurrencyData.Count > 0)
                ViewBag.DDLCurrencyID = DDLCurrencyData;
            else
                ViewBag.DDLCurrencyID = new List<SelectListItem> { };
        }

        public void FillCountryCombo()
        {
            string authorisation = token();

            requestendpoint = "";
            requestendpoint = Getrequestendpoint + "Common/CountryList/0";

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(requestendpoint);
            WebReq.Method = "GET";
            WebReq.Headers.Add("authorization", authorisation);
            WebReq.Headers.Add("Cache-Control", "no-cache");

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string jsontxt = _Answer.ReadToEnd();

            var DDLCountryData = JsonConvert.DeserializeObject<List<Models.APIModel>>(jsontxt);
            if (DDLCountryData != null && DDLCountryData.Count > 0)
                ViewBag.DDLCountryID = DDLCountryData;
            else
                ViewBag.DDLCountryID = new List<SelectListItem> { };
        }

        public void FillDesignationCombo()
        {
            string authorisation = token();

            requestendpoint = "";
            requestendpoint = Getrequestendpoint + "Common/DesignationList/0";

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(requestendpoint);
            WebReq.Method = "GET";
            WebReq.Headers.Add("authorization", authorisation);
            WebReq.Headers.Add("Cache-Control", "no-cache");

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string jsontxt = _Answer.ReadToEnd();

            var DDLDesignationData = JsonConvert.DeserializeObject<List<Models.APIModel>>(jsontxt);
            if (DDLDesignationData != null && DDLDesignationData.Count > 0)
                ViewBag.DDLDesignationID = DDLDesignationData;
            else
                ViewBag.DDLDesignationID = new List<SelectListItem> { };
        }

        public void FillIndustryCombo()
        {
            string authorisation = token();

            requestendpoint = "";
            requestendpoint = Getrequestendpoint + "Common/IndustryList/0";

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(requestendpoint);
            WebReq.Method = "GET";
            WebReq.Headers.Add("authorization", authorisation);
            WebReq.Headers.Add("Cache-Control", "no-cache");

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string jsontxt = _Answer.ReadToEnd();

            var DDLIndustryData = JsonConvert.DeserializeObject<List<Models.APIModel>>(jsontxt);
            if (DDLIndustryData != null && DDLIndustryData.Count > 0)
                ViewBag.DDLIndustryID = DDLIndustryData;
            else
                ViewBag.DDLIndustryID = new List<SelectListItem> { };
        }

        public void UploadImages(int Id = 0, HttpPostedFileBase TradeLicUpd = null)
        {
            string authorisation = token();

            // POST METHODE
            requestendpoint = "";
            requestendpoint = Getrequestendpoint + "Customer/CustomerDocAdd";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestendpoint);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("authorization", authorisation);
            httpWebRequest.Headers.Add("Cache-Control", "no-cache");
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //var avatar = new File
                //{
                //    FileName = System.IO.Path.GetFileName(upload.FileName),
                //    FileType = FileType.Avatar,
                //    ContentType = upload.ContentType
                //};
                //using (var reader = new System.IO.BinaryReader(upload.InputStream))
                //{
                //    avatar.Content = reader.ReadBytes(upload.ContentLength);
                //}

                byte[] input = null;
                using (var reader = new System.IO.BinaryReader(TradeLicUpd.InputStream))
                {
                    input = reader.ReadBytes(TradeLicUpd.ContentLength);
                }

                //byte[] input = new byte[TradeLicUpd.ContentLength];
                //using (Stream s = TradeLicUpd.InputStream)
                //{
                //    s.Read(input, 0, TradeLicUpd.ContentLength);
                //}

                //var _path = Path.GetFileName(TradeLicUpd.FileName);
                //ImageConverter _imageConverter = new ImageConverter();
                //byte[] xByte = (byte[])_imageConverter.ConvertTo(TradeLicUpd, typeof(byte[]));


                string json = new JavaScriptSerializer().Serialize(new
                {
                    tempcustomerid = Id,
                    docupload = input,

                });

                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public void storeError(Exception ex)
        {
            if (ex.InnerException == null) { ViewBag.ErrorMesssage = ex.Message; fn.LogFileWrite(ex.Message); } else { ViewBag.ErrorMesssage = ex.InnerException.Message; fn.LogFileWrite(ex.Message); }
        }
       
        public string token()
        {
            requestendpoint = "";
            requestendpoint = Getrequestendpoint + "auth/authenticate";
            string token = "fail";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestendpoint);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    user = apikey
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                dynamic jobject = JsonConvert.DeserializeObject(result);

                bool success = Convert.ToBoolean(jobject.success);
                if (success)
                {
                    token = jobject.token;
                }

            }
            return token;
        }

    }
}
