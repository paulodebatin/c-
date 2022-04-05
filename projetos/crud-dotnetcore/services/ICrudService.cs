using System.Collections.Generic;
using backend_dotnetcore.models;



namespace backend_dotnetcore.services 
{
    public interface ICrudService<E>  {

        IEnumerable<E> getAll();
        E getById(int id);
        E save(E entidade);
        E update(int id, E produto);
        void delete(int id); 


    }
}    