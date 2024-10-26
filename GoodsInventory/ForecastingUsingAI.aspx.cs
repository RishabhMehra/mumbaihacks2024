using GoodsInventory.Model;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodsInventory
{
    public partial class ForecastingUsingAI : System.Web.UI.Page
    {
        string aiResponse = "\nAI Data Loading . . .";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            if (!txtChatQuery.Text.IsNullOrWhiteSpace())
            {
                ///*test data*/
                //StringResponseDateModel stringResponseDateModeltst = new StringResponseDateModel()
                //{
                //    current_day = 2,
                //    detected_temporal_word = "asdsd",
                //    computed_date = new ComputedDate()
                //};
                //var serializedObj = JsonConvert.SerializeObject(stringResponseDateModeltst);
                //StringResponseDateModel stringResponseDateModel_tes = JsonConvert.DeserializeObject<StringResponseDateModel>(serializedObj);

                StringResponseDateModel stringResponseDateModel =  await StringDateApiCall();
                string aiResponse = await callAiApi(stringResponseDateModel);
                txtChatWindow.Text = (txtChatWindow.Text.Replace(aiResponse, "")) + "\n" + "User : " + txtChatQuery.Text+ "\n " + aiResponse;
                txtChatQuery.Text = "";
                txtChatQuery.Focus();
            }
        }

        //protected void tmrChatWindow_Tick(object sender, EventArgs e)
        //{
        //    if (txtChatWindow.Text.EndsWith("Loading . . ."))
        //        txtChatWindow.Text = txtChatWindow.Text.Replace("Loading . . .", "Loading");
        //    else if (txtChatWindow.Text.EndsWith("Loading . ."))
        //        txtChatWindow.Text = txtChatWindow.Text.Replace("Loading . .", "Loading . . .");
        //    else if (txtChatWindow.Text.EndsWith("Loading ."))
        //        txtChatWindow.Text = txtChatWindow.Text.Replace("Loading .", "Loading . .");
        //    else if (txtChatWindow.Text.EndsWith("Loading"))
        //        txtChatWindow.Text = txtChatWindow.Text.Replace("Loading", "Loading .");
        //}

        private async Task<string> callAiApi(StringResponseDateModel stringResponseDateModel)
        {
            string result = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, System.Configuration.ConfigurationManager.AppSettings["PredictApiUrl"]);
            var content = new MultipartFormDataContent();
            //content.Add(new StringContent("1"), "quantity");
            //content.Add(new StringContent("2"), "pizza_size");
            //content.Add(new StringContent("1"), "pizza_category");
            content.Add(new StringContent(stringResponseDateModel.current_day.ToString()), "Day");
            content.Add(new StringContent(stringResponseDateModel.current_month.ToString()), "Month");
            content.Add(new StringContent(stringResponseDateModel.current_hour.ToString()), "Hour");
            content.Add(new StringContent("1"), "is_peak");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsStringAsync();
            return result;
        }

        private async Task<StringResponseDateModel> StringDateApiCall()
        {
            string result = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, System.Configuration.ConfigurationManager.AppSettings["StringDateApiUrl"]);
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(txtChatQuery.Text), "date_str");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StringResponseDateModel>(result);
        }
    }
}