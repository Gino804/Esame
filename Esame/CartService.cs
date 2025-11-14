using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Esame
{
    public class CartService
    {
        private readonly string _cartFilePath;

        public CartService()
        {
            // Definisci il percorso del file JSON che conterrà il carrello
            _cartFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cart.json");
        }

        // Aggiungi un prodotto al carrello
        public async Task AddToCart(Product product)
        {
            var cart = await GetCartAsync();
            cart.Add(product);
            await SaveCartAsync(cart);
        }

        // Ottieni tutti i prodotti nel carrello
        public async Task<List<Product>> GetCartAsync()
        {
            if (File.Exists(_cartFilePath))
            {
                var json = await File.ReadAllTextAsync(_cartFilePath);
                return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            }
            return new List<Product>();
        }

        // Salva il carrello nel file JSON
        private async Task SaveCartAsync(List<Product> cart)
        {
            var json = JsonSerializer.Serialize(cart, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_cartFilePath, json);
        }
    }
}
