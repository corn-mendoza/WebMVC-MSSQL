using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebMVC_MSSQL.Models
{
    public class Release
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [ConcurrencyCheck]
        [Required]
        public string ApplicationName { get; set; }

        [Display(Name = "Version")]
        public string VersionText { get; set; }

        [Display(Name = "Link")]
        [DataType(DataType.Url)]
        public string DownloadLink { get; set; }

        [DataType(DataType.Text)]
        public string Build { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal StorePrice { get; set; }

        public List<ReleaseNote> ReleaseNotes { get; set; }
    }
}
