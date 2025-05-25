using System.ComponentModel.DataAnnotations;

namespace API_EM_C_.Model
{
    public class LoginModel
    {
        [Key]
        public string Usuario { get; set; }
        public string Senha { get; set; }       
    }
}
