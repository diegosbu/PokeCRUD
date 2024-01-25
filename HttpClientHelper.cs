namespace API_Usage_Fix {
    public static class HttpClientHelper {

        private static HttpClient HttpClientInstance = new HttpClient();

        public static HttpClient GetHttpClientHelper() {
            return HttpClientInstance;
        }
    }
}
