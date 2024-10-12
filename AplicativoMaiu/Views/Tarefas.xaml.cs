using System.Collections.ObjectModel;

namespace AplicativoMaiu;
public class Tarefa
{
public bool Concluida { get; set; }

public string Nome { get; set; }

}
public partial class Tarefas : ContentPage
{
    // ObservableCollection para atualizar a lista automaticamente
    ObservableCollection<Tarefa> tasks;

    public Tarefas()
    {
        InitializeComponent();
        tasks = new ObservableCollection<Tarefa>();
        taskListView.ItemsSource = tasks;
    }

    // adicionar nova tarefa
    private void OnAddTaskClicked(object sender, EventArgs e)
    {
        string newTask = taskEntry.Text;

        if (!string.IsNullOrWhiteSpace(newTask))
        {
            var tarefa = new Tarefa { Nome = newTask, Concluida = false };
            tasks.Add(tarefa);
            Console.WriteLine($"Tarefa adicionada: {tarefa.Nome}"); 
            taskEntry.Text = string.Empty;
        }
        else
        {
            DisplayAlert("Erro", "A tarefa não pode estar vazia", "OK");
        }
    }
}