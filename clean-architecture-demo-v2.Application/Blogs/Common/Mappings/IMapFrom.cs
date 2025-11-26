using AutoMapper;

namespace clean_architecture_demo_v2.Application.Blogs.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
