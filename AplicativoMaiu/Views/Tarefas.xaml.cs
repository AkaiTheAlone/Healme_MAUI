using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AplicativoMaiu
{
    public class Tarefa
    {
        public bool Concluida { get; set; }
        public string Nome { get; set; }
    }

    public partial class Tarefas : ContentPage
    {
        public ObservableCollection<Tarefa> Tasks { get; set; }

        public ICommand RemoverTarefaCommand => new Command<Tarefa>((tarefa) => RemoverTarefa(tarefa));
        public Tarefas()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<Tarefa>();
            taskListView.ItemsSource = Tasks;
            BindingContext = this;
        }

        private void RemoverTarefa(Tarefa tarefa)
        {
            if (tarefa != null && Tasks.Contains(tarefa))
            {
                Tasks.Remove(tarefa);
                Console.WriteLine("Tarefa removida!");
            }
        }

        private void AdicionarNovaTarefa(object sender, EventArgs e)
        {
            string newTask = taskEntry.Text;
            if (!string.IsNullOrWhiteSpace(newTask))
            {
                var tarefa = new Tarefa { Nome = newTask, Concluida = false };
                Tasks.Add(tarefa);
                Console.WriteLine($"Tarefa adicionada: {tarefa.Nome}");
                taskEntry.Text = string.Empty;
            }
            else
            {
                DisplayAlert("Erro", "A tarefa não pode estar vazia", "OK");
            }
        }
    }
}
