using System.Collections.Generic;

namespace PlanesTrainsandAutomobiles.Interfaces
{
    public interface IRepository<T, Tid>
    {
        List<T> GetAll();

        T GetById(string id);

        T Create(T data);

        T Edit(T data);

        string Delete(Tid id);

    }
}