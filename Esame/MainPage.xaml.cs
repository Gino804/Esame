namespace Esame
{
    public partial class MainPage : ContentPage
    {
        RestService service;
        private List<Product> _items;
        public List<Product> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();  // Notifica il cambio della proprietà
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            service = new RestService();

            // Impostiamo il BindingContext sulla pagina
            BindingContext = this;
        }

        // Metodo per caricare i dati quando la pagina viene caricata
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Items = await service.GetProductsAsync();
            // Informa il sistema di binding che i dati sono stati aggiornati
            OnPropertyChanged(nameof(Items));
        }

        private async void OnCounterClicked(object? sender, EventArgs e) 
        {
            var service = new RestService();
            var products = await service.GetProductsAsync();
        }
    }

}
