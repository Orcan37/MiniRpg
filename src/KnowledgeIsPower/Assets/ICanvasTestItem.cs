using CodeBase.Infrastructure.Services;

public interface ICanvasTestItem : IService
{
    int money { get; set; }
    int diamond{ get; set; }
    void AnimShow(int count);
}