namespace Poke_CRUD_App.Classes {
    public static class HttpClientHelper {

        private static HttpClient HttpClientInstance = new HttpClient();

        public static HttpClient GetHttpClientHelper() {
            return HttpClientInstance;
        }
    }
}
