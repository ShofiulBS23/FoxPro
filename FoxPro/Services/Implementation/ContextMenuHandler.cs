//using System;
//using System.IO;
//using System.Windows.Forms;

//namespace FoxPro.Services.Implementation;

//public class ContextMenuHandler
//{
//    private ITaskUI _ui;
//    private ITask _task;

//    public ContextMenuHandler(ITaskUI ui, ITask task)
//    {
//        _ui = ui;
//        _task = task;
//    }

//    public void OpenTask()
//    {
//        var taskEditor = new TaskEditor(_task);
//        taskEditor.ShowModal();
//    }

//    public void PrintTask()
//    {
//        // Implementation for printing a task
//    }

//    public void OpenFile()
//    {
//        var fileType = Path.GetExtension(_task.FileName).ToUpperInvariant();
//        switch (fileType) {
//            case "VCX":
//            case "PRG":
//            case "TXT":
//                // Open the file with associated editor
//                break;
//            default:
//                // Handle other file types
//                break;
//        }
//    }

//    public void Import()
//    {
//        // Implementation for importing tasks or data
//    }

//    public void Export()
//    {
//        // Implementation for exporting tasks or data
//    }

//    public void UpdateStatus(int newStatus)
//    {
//        _task.Status ^= newStatus;
//        _ui.UpdateTask(_task);
//    }

//    public void DeleteTask()
//    {
//        if (MessageBox.Show("Are you sure?", "Delete Task", MessageBoxButtons.YesNo) == DialogResult.Yes) {
//            _ui.RemoveTask(_task.UniqueId);
//        }
//    }

//    public void ShowTasks(int filter, bool state)
//    {
//        // Filter and update task list display based on state
//    }

//    public void ColumnChooser()
//    {
//        // Handle column choosing logic
//    }

//    public void RemoveColumn(int columnIndex)
//    {
//        // Remove column logic
//    }

//    public void Options()
//    {
//        var options = new TaskOptions(_ui.TaskList);
//        options.Show();
//    }

//    public void CleanUp()
//    {
//        var fileName = "tasks.dbf"; // Example DBF file name
//        try {
//            // Pack the DBF file, handle exceptions
//        } catch (Exception ex) {
//            MessageBox.Show("Error during pack operation.");
//        }
//    }
//}
