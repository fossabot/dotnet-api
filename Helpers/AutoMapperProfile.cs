using AutoMapper;
using backend.Entities;
using backend.Models.Users;

namespace backend.Helpers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<User, UserModel>();
			CreateMap<RegisterModel, User>();
			CreateMap<UpdateUserModel, User>();
		}
	}
}
