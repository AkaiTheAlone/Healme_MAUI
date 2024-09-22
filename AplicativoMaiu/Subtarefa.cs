using System.Collections.ObjectModel;

public class TarefaItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public ObservableCollection<SubtarefaItem> Subtasks { get; set; }

    public TarefaItem()
    {
        Subtasks = new ObservableCollection<SubtarefaItem>();
    }

    public bool AreSubtasksCompleted()
    {
        return Subtasks.All(subtask => subtask.IsCompleted);
    }
}

public class SubtarefaItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}