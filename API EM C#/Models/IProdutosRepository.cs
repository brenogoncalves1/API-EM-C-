namespace API_EM_C_.Model
{
    public interface IProdutosRepository
    {
        void add(Produtos produtos);
        void delete(Produtos produtos);
        List<Produtos> get();
        void update(Produtos produtos);
    }
}
