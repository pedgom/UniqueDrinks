using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueDrinks.Models
{
    public class ImagensBebidas
    {
        public ICollection<Imagens> ListaDeImagens { get; set; }

        /// <summary>
        /// lista dos IDs dos cães que pertencem à pessoa autenticada
        /// </summary>
        public ICollection<int> ListaDeBebidas { get; set; }

    }

    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }


}
