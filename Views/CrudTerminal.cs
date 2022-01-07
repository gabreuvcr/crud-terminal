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

        private void Menu()
        {
            Console.WriteLine("CRUD DE FUNCIONARIOS");
            Console.WriteLine("[1] Listar todos funcionarios");
            Console.WriteLine("[2] Listar pelo id do funcionario");
            Console.WriteLine("[3] Adicionar funcionario");
            Console.WriteLine("[4] Remover funcionario pelo id");
            Console.WriteLine("[5] Atualizar pelo id");
            Console.WriteLine("[6] Parar");
            Console.Write("\nDigite uma opcao: ");
        }

        private void InvalidInput()
        {
            Console.WriteLine("Valor invalido, selecione um numero entre 0-9");
            Console.WriteLine("Pressione Enter para continuar");
        }

        private int Confirmation(Employee employee)
        {
            Console.WriteLine($"\nFuncionario com ID {employee.Id}:");
            Console.WriteLine($"{employee}\n");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Nao");
            Console.Write("Tem certeza que deseja continuar? ");
            int confirmation = Int32.Parse(Console.ReadLine());
            return confirmation;
        }

        private EmployeeDTO EmployeeInput()
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            Console.WriteLine("Insira os novos valores: ");
            Console.Write("Digite o nome: ");
            employeeDTO.Name = Console.ReadLine();
            Console.Write("Digite o salario: ");
            employeeDTO.Salary = Double.Parse(Console.ReadLine());
            Console.Write("Digite a funcao: ");
            employeeDTO.Role = Console.ReadLine();
            Console.WriteLine("[1] Masculino");
            Console.WriteLine("[2] Feminino");
            Console.WriteLine("[3] Outro");
            Console.Write("Digite o genero: ");
            employeeDTO.Gender = (Gender) Int16.Parse(Console.ReadLine());
            return employeeDTO;
        }

        private void ListEmployeeById()
        {
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Employee employee = service.FindEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine($"\nFuncionario com ID {id} nao encontrado\n");
                return;
            }

            Console.WriteLine($"\nFuncionario com ID {id}:");
            Console.WriteLine($"{employee}\n");
        } 

        private void ListAllEmployees()
        {
            Console.WriteLine();
            List<Employee> employees = service.FindAllEmployees();
            if (employees.Count == 0) {
                Console.WriteLine("Nenhum funcionario cadastrado\n");
                return;
            }
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"ID {employee.Id}: {employee}");
            }
            Console.WriteLine();
        } 

        private void AddEmployee()
        {
            EmployeeDTO employeeDTO = EmployeeInput();
            
            Employee employee = new Employee(employeeDTO);
            service.AddEmployee(employee);
        } 

        private void RemoveEmployeeById()
        {
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Employee employee = service.FindEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine($"\nFuncionario com ID {id} nao encontrado\n");
                return;
            }

            int confirmation = Confirmation(employee);

            if (confirmation == 2) return;

            service.RemoveEmployeeById(id);
            Console.WriteLine("Funcionario excluido com sucesso");
        }

        private void UpdateEmployeeById()
        {
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Employee employee = service.FindEmployeeById(id);

            if (employee == null)
            {
                Console.WriteLine($"\nFuncionario com ID {id} nao encontrado\n");
                return;
            }

            int confirmation = Confirmation(employee);

            if (confirmation == 2) return;

            EmployeeDTO employeeDTO = EmployeeInput();
            employeeDTO.Id = id;

            service.UpdateEmployeeById(employeeDTO);

            employee = service.FindEmployeeById(id);
            Console.WriteLine(employee);
            Console.WriteLine("Funcionario atualizado com sucesso");
        }

        public void Run()
        {
            short option;
            while (true)
            {
                Menu();

                try
                {
                    option = Int16.Parse(Console.ReadLine());
                }
                catch 
                {
                    InvalidInput();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        ListAllEmployees();
                        break;

                    case 2:
                        ListEmployeeById();
                        break;

                    case 3:
                        AddEmployee();
                        break;

                    case 4:
                        RemoveEmployeeById();
                        break;

                    case 5:
                        UpdateEmployeeById();
                        break;

                    case 6:
                        return;

                    default:
                        InvalidInput();
                        break;
                }
                Console.Write("Pressione enter para continuar...");
                Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}
