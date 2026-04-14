using System.ComponentModel.DataAnnotations;

namespace StudyPlanner.Models
{
    public class StudyTaskViewModel
    {
        [Required(ErrorMessage = "Введите предмет")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Введите название")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Укажите дедлайн")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "Выберите приоритет")]
        public string Priority { get; set; }
    }
}
