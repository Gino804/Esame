namespace Esame;

public partial class DetailPage : ContentPage
{
    private readonly CartService _cartService;
    public DetailPage()
	{
		InitializeComponent();
        _cartService = new CartService();
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        var product = BindingContext as Product;
        if (product != null)
        {
            await _cartService.AddToCart(product);
            await DisplayAlert("Successo", "Prodotto aggiunto al carrello!", "OK");
        }
    }
}