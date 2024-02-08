using System;
using System.Net.NetworkInformation;
using ToDoListAPI.Data.ValueObjects;
using ToDoListAPI.Model;

namespace ToDoListAPI.Messages
{
    public class Messages
    {
        public static string UnexpectedErrorMessage = "Erro inesperado, favor consultar o administrador.";
        public static string NotFoundDatasForThisRouteMessage = "Não houveram resultados para a pesquisa.";
        public static string NotFoundDataForThisIdMessage = "Não Existem informações para o Id informado.";
        public static string ErrorObjectNullMessage = "Objeto não pode ser nulo";
        public static string ErrorUpdateTaskMessage = "Não foi possível atualizar a task.";
        public static string ErrorUpdateDataBaseMessage = "Erro interno, não foi possível atualizar a task.";

        #region LOGS

        public string BeginRequestMessage(string context = null)
        {
            return $"Inicio da requisição {(string.IsNullOrWhiteSpace(context) ? "no contexto: " + context : string.Empty)} - {DateTime.Now}";
        }
        public string SearchAnyIntoDatabase(string any = null)
        {
            return $"Buscando {any} em banco de dados";
        }
        public string CreateTaskIntoDataBase(TaskToDo task = null)
        {
            return $"Criando uma nova Task com o Título {task.Title}";
        }
        public string UpdateTaskExisting(TaskToDo task = null)
        {
            return $"Atualizando a Task com o Id {task.Id}";  
        }
        public string DeletingTaskWithId(long id)
        {
            return $"Excluindo a Task com o Id:{id}";
        }
        public string ErrorLog(string error = null)
        {
            return $"Não Foi Possível Encontrar Informações, Erro : {error}";
        }
        public string ErrorCreateTaskIntoDataBase(string error = null)
        {
            return $"Não Foi Possível Criar uma nova tarefa, erro:{error}";
        }

        #endregion
    }
}
