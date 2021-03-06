/*
 * MIT License (MIT)
 * Copyright (c) 2018
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace ActiveLedgerLib
{
    public static class MakeRequest
    {
        public static HttpResponseMessage Response;

        //posting the Async resquest to active Ledger
        #region makeRequestAsync Method
        public static async Task<HttpResponseMessage> makeRequestAsync(string endpoint, string json)
        {


            using (var client = new HttpClient())
            {
                 // var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(json));
               var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                //getting response 
            
               Response = await client.PostAsync(endpoint,httpContent).ConfigureAwait(false);


            };

            return Response;

        }
        #endregion makeRequestAsync Method


        //getting the territoriality details from the ledger
        #region getTerritorialityDetails Method
        public static async Task<HttpResponseMessage> getTerritorialityDetails(string endpoint)
        {


            using (var client = new HttpClient())
            {

                Response = await client.GetAsync(endpoint+"/a/status").ConfigureAwait(false);


            };

            return Response;

        }
        #endregion getTerritorialityDetails Method

    }
}

