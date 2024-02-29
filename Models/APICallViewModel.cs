namespace Poke_CRUD_App.Models {
    public class ApiCallViewModel {
        public string? pokemonName {  get; set; }
        public string? pokemonImgSrc { get; set; }

        public ApiCallViewModel() {}

        public ApiCallViewModel(string name, string imgSrc) {
            this.pokemonName = name;
            this.pokemonImgSrc = imgSrc;
        }
    }
}
