using AutoMapper;
using GeekShopping.ProductApi.ValueObjects;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        private IMapper _mapper;

        public ProductRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public Task<ProductVO> Create(ProductVO productVO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductVO> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductVO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductVO> Update(ProductVO productVO)
        {
            throw new NotImplementedException();
        }
    }
}
