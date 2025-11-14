namespace Esame;

public partial class CartPage : ContentPage
{
    private readonly CartService _cartService;

    public List<Product> CartItems { get; set; }
    public CartPage()
	{
        InitializeComponent();
        _cartService = new CartService();
        LoadCartItems();
    }

    private async void LoadCartItems()
    {
        CartItems = await _cartService.GetCartAsync();
        BindingContext = this;
    }
}