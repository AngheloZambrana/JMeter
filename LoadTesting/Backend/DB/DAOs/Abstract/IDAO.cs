namespace Backend.DB.DAOs.Abstract;

public interface IDAO<T>
{
    List<T> ReadAll();
}