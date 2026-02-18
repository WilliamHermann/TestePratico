using Moq;
using Xunit;
using TestePratico.WebApi.Application.DTOS;
using TestePratico.WebApi.Application.Interfaces;
using TestePratico.WebApi.Application.Services;
using TestePratico.WebApi.Domain.Entities;
using TestePratico.WebApi.Domain.Enums;

namespace TesteUnitarios
{
    // Como os services estão bem simples, não tem muita regra de negócio para testar, mas adicionei os testes para demonstrar como seria em uma situação real.
    public class VeiculoTestes
    {
        [Fact]
        public async Task CadastrarVeiculo_DadosValidos_DeveRetornarSucesso()
        {
            //Arrange
            var mockRepo = new Mock<IVeiculoRepository>();
            mockRepo.Setup(repo => repo.CriarAsync(It.IsAny<Veiculo>()))
            .ReturnsAsync(new Veiculo
            {
                Id = 1,
                Descricao = "Carro confortável",
                Marca = Marca.Mercedes,
                Modelo = "HB20 CONFORT",
                Valor = 80000
            });

            var veiculoService = new VeiculoService(mockRepo.Object);

            var novoVeiculo = new CadastrarVeiculoDTO("Carro confortável", Marca.Mercedes, "HB20 CONFORT", 80000);

            //Act
            var resultado = await veiculoService.CriarAsync(novoVeiculo);

            //Assert
            Assert.NotNull(resultado);
            Assert.Equal(novoVeiculo.Descricao, resultado.Descricao);
            Assert.Equal(novoVeiculo.Marca, resultado.Marca);
            Assert.Equal(novoVeiculo.Modelo, resultado.Modelo);
            Assert.Equal(novoVeiculo.Valor, resultado.Valor);

            // Verifica se o método CriarAsync do repositório foi chamado com os mesmos dados
            mockRepo.Verify(r => r.CriarAsync(
            It.Is<Veiculo>(v =>
                v.Descricao == "Carro confortável" &&
                v.Marca == Marca.Mercedes &&
                v.Valor == 80000)
            ), Times.Once);
        }

        [Fact]
        public async Task AtualizarVeiculo_DadosValidos_DeveRetornarSucesso()
        {
            //Arrange
            var mockRepo = new Mock<IVeiculoRepository>();
            var veiculoService = new VeiculoService(mockRepo.Object);

            var veiculoExistente = new Veiculo
            {
                Id = 1,
                Descricao = "Carro confortável",
                Marca = Marca.Mercedes,
                Modelo = "HB20 CONFORT",
                Valor = 80000
            };

            var dadosAtualizados = new AtualizarVeiculoDTO("Carro esportivo", Marca.Bmw, "M3 Competition", 3000000);

            //Act
            await veiculoService.AtualizarAsync(veiculoExistente, dadosAtualizados);

            //Assert
            Assert.Equal(dadosAtualizados.Descricao, veiculoExistente.Descricao);
            Assert.Equal(dadosAtualizados.Marca, veiculoExistente.Marca);
            Assert.Equal(dadosAtualizados.Modelo, veiculoExistente.Modelo);
            Assert.Equal(dadosAtualizados.Valor, veiculoExistente.Valor);

            // Verifica se o método AtualizarAsync do repositório foi chamado com os mesmos dados
            mockRepo.Verify(r => r.AtualizarAsync(
                It.Is<Veiculo>(v =>
                    v.Id == 1 &&
                    v.Descricao == "Carro esportivo" &&
                    v.Marca == Marca.Bmw &&
                    v.Modelo == "M3 Competition" &&
                    v.Valor == 3000000)
                ), Times.Once);
        }

        // Outros testes como verificar quando deve acontecer um erro, ou quando o veículo não existe para atualizar...
    }
}