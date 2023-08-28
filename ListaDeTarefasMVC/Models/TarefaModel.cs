using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefasMVC.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [StringLength(250, ErrorMessage = "Campo permiti o maximo 250 caracteres")]
        public string Nome { get; set; }

        public string Data { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Time)] 
        public string Horario { get; set; }
    }
}
