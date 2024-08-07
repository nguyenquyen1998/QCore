namespace QCore.Domain.Entities;

public interface IHasKey<T>{
    T Id { set; get; }
}