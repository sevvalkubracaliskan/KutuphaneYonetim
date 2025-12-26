using System;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneYonetim.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur")]
        [StringLength(120, ErrorMessage = "Kitap adı en fazla 120 karakter olmalıdır")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Yazar adı zorunludur")]
        [StringLength(80, ErrorMessage = "Yazar adı en fazla 80 karakter olmalıdır")]
        public string Author { get; set; } = "";

        // ✅ Boş gelirse artık İngilizce parse hatası yerine Türkçe Required çalışacak
        [Required(ErrorMessage = "Sayfa sayısı zorunludur")]
        [Range(1, 5000, ErrorMessage = "Sayfa sayısı 1 ile 5000 arasında olmalıdır")]
        public int? PageCount { get; set; }

        // ✅ Boş gelirse artık İngilizce parse hatası yerine Türkçe Required çalışacak
        [Required(ErrorMessage = "Yayın tarihi zorunludur")]
        [DataType(DataType.Date)]
        public DateTime? PublishDate { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır")]
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}