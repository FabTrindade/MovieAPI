using System;
using System.ComponentModel.DataAnnotations;


namespace MovieAPI.Data.Dtos
{
    public class GetMovieDto
    {
        [Key]
        [Required]
        public int Id { get; set; }     
        [Required (ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }
        [Required (ErrorMessage = "The Diector field is required.")]
        public string Director { get; set; }
        public string Genre { get; set; }        
        [Range(1, 360)]
        public int Duration { get; set; }    
        public DateTime ConsultTime {get; set;}       
    }
}