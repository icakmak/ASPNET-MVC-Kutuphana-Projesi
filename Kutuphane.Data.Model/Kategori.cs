using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Data.Model
{
    public class Kategori:BaseEntity
    {
        //Burada Yapılan değişiklikler oluşturulan db 'de tablo üstünde değişiklik yapmaktadır.
        [Required] //Bu Alanın Zorunlu olduğu belirtilmekte
        [Column(TypeName="varchar")] //Tipi varchar olarak değiştirilmekte
        [MaxLength(50)] // Değer uzunluğu 50 karakter olarak ayarlanmaktadır.
        public string Ad { get; set; }

        public List<Kitap> Kitaplar { get; set; }

    }
}
