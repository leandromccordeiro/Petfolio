using Microsoft.AspNetCore.Mvc.Filters;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.UseCases.Pets.Register
{
    public class RegisterPetUseCase
    {
        #region DICA
        /*
         Seguindo o princípio da responsabilidade única e as boas práticas, de forma que o código
        fique mais intuitivo e objetivo, o ideal é que cada regra de negócio possua apenas 1 
        função pública, que será a regra que vai ser aplicada ao caso.

        Obs: Não é proibido ter outras funções privada para auxiliar a função central.
         */
        #endregion

        #region EXPLICAÇÃO FUNÇÃO EXECUTE
        /*
         É interessante padronizar a função principal da regra de negócio. "Execute" é um 
        nome intuitivo, então vou utilizá-lo em projetos pessoais. 

        A função Execute vai executar a regra de negócio com base em uma request passada pela
        classe resonsável (communication -> request), que será usada como parâmetro para 
        a função, que será do tipo Response, que devolverá uma response de acordo com a regra 
         */
        #endregion

        public ResponseRegisterPetJson Execute(RequestPetJson request)
        {
            return new ResponseRegisterPetJson
            {
                Id = 7,
                Name = request.Name,
            };
        }
    }
}
