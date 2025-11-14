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

        // Metodo che gestisce la selezione di un prodotto
        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                // Prendi il prodotto selezionato
                var selectedProduct = e.CurrentSelection[0] as Product;

                // Naviga alla pagina dei dettagli passando il prodotto
                await Navigation.PushAsync(new DetailPage { BindingContext = selectedProduct });
            }
        }

        private async void OnViewCartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage());
        }

        private async void OnCounterClicked(object? sender, EventArgs e) 
        {
            var service = new RestService();
            var products = await service.GetProductsAsync();
        }
    }

}
