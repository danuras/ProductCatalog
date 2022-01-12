using ProductCatalog.Model.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Model.Repository
{
    public class ProductRestApiRepository
    {
        /// <summary>
        /// Method untuk menampilkan semua product
        /// </summary>
        /// <returns>Object collection dari product</returns>
        public List<Product> ReadAll()
        {
            string baseUrl = "http://responsi.coding4ever.net:5555/";
            string endpoint = "api/product";

            // membuat objek rest client
            var client = new RestClient(baseUrl);

            // membuat objek request
            var request = new RestRequest(endpoint, Method.GET);

            // kirim request ke server
            var response = client.Execute<List<Product>>(request);

            return response.Data;
        }

        /// <summary>
        /// Method untuk pencarian data product berdasarkan nama product
        /// </summary>
        /// <param name="productName"></param>
        /// <returns>Object collection dari product</returns>
        public List<Product> ReadByProductName(string productName)
        {
            string baseUrl = "http://responsi.coding4ever.net:5555/";
            string endpoint = "api/product?product_name=" + productName;

            // membuat objek rest client
            var client = new RestClient(baseUrl);

            // membuat objek request
            var request = new RestRequest(endpoint, Method.GET);

            // kirim request ke server
            var response = client.Execute<List<Product>>(request)??null;

            return response.Data;
        }

        /// <summary>
        /// Method untuk pencarian data product berdasarkan category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Object collection dari product</returns>
        public List<Product> ReadByCategory(string category)
        {
            string baseUrl = "http://responsi.coding4ever.net:5555/";
            string endpoint = "api/product?category=" + category;

            // membuat objek rest client
            var client = new RestClient(baseUrl);

            // membuat objek request
            var request = new RestRequest(endpoint, Method.GET);

            // kirim request ke server
            var response = client.Execute<List<Product>>(request) ?? null;

            return response.Data;
        }

        /// <summary>
        /// Method untuk pencarian data product berdasarkan kode produk
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Object product</returns>
        public Product ReadByProductId(string productId)
        {
            string baseUrl = "http://responsi.coding4ever.net:5555/";
            string endpoint = "api/product/" + productId;

            // membuat objek rest client
            var client = new RestClient(baseUrl);

            // membuat objek request
            var request = new RestRequest(endpoint, Method.GET);

            // kirim request ke server
            var response = client.Execute<List<Product>>(request);

            return response.Data[0];
        }
    }
}
