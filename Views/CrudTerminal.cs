using System;
using System.Collections.Generic;
using Laboratory.Models;
using Laboratory.Models.DTOs;
using Laboratory.Models.Enums;
using Laboratory.Services;

namespace Laboratory.Views
{
    public class CrudTerminal
    {
        private CrudService service = new CrudService();
        
        public CrudTerminal() { }

        public void Run()
        {
            int option;
            while (true)
            {
                option = Home();
                Switch(option);
                PressToContinue();
            }
        }

        private int Home()
        {
            Console.Clear();
            Console.WriteLine("CRUD DE FUNCIONARIOS");
            int option = Menu(options: new List<string> {
                    "Listar todos funcionarios", "Listar pelo id do funcionario",
                    "Adicionar funcionario", "Remover funcionario pelo id",
                    "Atualizar pelo id", "Parar"
                },
                text: "Digite uma opcao:"
            );
            return option;
        }

        private void Switch(int option)
        {
            switch (option)
            {
                case 1: ListAllEmployees(); break;
                case 2: ListEmployeeById(); break;
                case 3: AddEmployee(); break;
                case 4: RemoveEmployeeById(); break;
                case 5: UpdateEmployeeById(); break;
                case 6: Environment.Exit(0); break;
                default: InvalidInput(); break;
            }
        }

        private int Menu(List<string> options, string text)
        { 
            int option;
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {options[i]}");
            }
            while ((option = ValidInput.Int(text, limit: options.Count)) == -1)
                InvalidInput();
            return option;
        }

        private void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("ADICIONAR FUNCIONARIO");
            EmployeeDTO employeeDTO = EmployeeInput("Insira os valores");
            
            Employee employee = new Employee(employeeDTO);
            service.AddEmployee(employee);

            Console.WriteLine($"\n{employee}");
            Console.WriteLine("\nFuncionario adicionado com sucesso");
        } 

        private void ListEmployeeById()
        {
            Console.Clear();
            Console.WriteLine("BUSCAR FUNCIONARIO");
            int id;
            while ((id = ValidInput.Int("Digite o ID:")) == -1)
                InvalidInput();

            Employee employee = service.FindEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine($"\nFuncionario com ID {id} nao encontrado");
                return;
            }

            Console.WriteLine($"\nID {id}: {employee}");
        } 

        private void ListAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("TODOS FUNCIONARIOS");
            Console.WriteLine();
            List<Employee> employees = service.FindAllEmployees();
            if (employees.Count == 0) {
                Console.WriteLine("Nenhum funcionario cadastrado");
                return;
            }
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"ID {employee.Id}: {employee}");
            }
        }
        
        private void UpdateEmployeeById()
        {
            Console.Clear();
            Console.WriteLine("ATUALIZAR FUNCIONARIO");
            int id;
            while ((id = ValidInput.Int("Digite o ID:")) == -1)
                InvalidInput();

            Employee employee = service.FindEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine($"\nFuncionario com ID {id} nao encontrado");
                return;
            }

            int confirmation = Confirmation(employee);

            if (confirmation == 2) return;

            EmployeeDTO employeeDTO = EmployeeInput("\nInsira os novos valores");
            employeeDTO.Id = id;

            service.UpdateEmployeeById(employeeDTO);

            employee = service.FindEmployeeById(id);
            Console.WriteLine($"\n{employee}");
            Console.WriteLine("\nFuncionario atualizado com sucesso");
        }

        private void RemoveEmployeeById()
        {
            Console.Clear();
            Console.WriteLine("REMOVER FUNCIONARIO");
            int id;
            while ((id = ValidInput.Int("Digite o ID:")) == -1)
                InvalidInput();

            Employee employee = service.FindEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine($"\nFuncionario com ID {id} nao encontrado");
                return;
            }

            int confirmation = Confirmation(employee);

            if (confirmation == 2) return;

            service.RemoveEmployeeById(id);
            Console.WriteLine("\nFuncionario excluido com sucesso");
        }

        private int Confirmation(Employee employee)
        {
            Console.WriteLine($"\nID {employee.Id}: {employee}\n");
            int confirmation = Menu(options: new List<string> {
                    "Sim", "Nao"
                },
                text: "Tem certeza que deseja continuar?"
            );
            return confirmation;
        }

        private EmployeeDTO EmployeeInput(string text)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            Console.WriteLine($"{text}");
            while ((employeeDTO.Name = ValidInput.String("Digite o nome:")).Equals(""))
                InvalidInput();
            while ((employeeDTO.Salary = ValidInput.Decimal("Digite o salario:")) == -1)
                InvalidInput();
            while ((employeeDTO.Role = ValidInput.String("Digite a funcao:")).Equals(""))
                InvalidInput();
            employeeDTO.Gender = (Gender) Menu(options: new List<string> {
                    "Masculino",
                    "Feminino",
                    "Outro"
                 },
                 text: "Digite o genero:"
            );
            return employeeDTO;
        }

        private void InvalidInput()
        {
            Console.WriteLine("Valor invalido.");
        }

        private void PressToContinue()
        {
            Console.Write("\nPressione enter para continuar...");
            Console.ReadLine();
        }
    }
}
