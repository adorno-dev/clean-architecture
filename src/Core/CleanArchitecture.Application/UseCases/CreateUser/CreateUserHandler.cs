using AutoMapper;
using CleanArchitecture.Domain.Contracts;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);

            userRepository.Create(user);

            await unitOfWork.Commit(cancellationToken);

            return mapper.Map<CreateUserResponse>(user);
        }
    }
}