﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Compra:Entity
    {
        public Compra( ) { }
        public Compra(string nome, 
            DateTime dateTime, 
            decimal price, 
            int quantidade, 
            string fornecedor
           )
        {
            Nome = nome;
            DateTime = dateTime;
            Price = price;
            Quantidade = quantidade;
            Fornecedor = fornecedor;
            Total = this.TotalCal(Price,Quantidade);
        }

        public string Nome { get; set; }
        [Display(Name = "Data de Compra")]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [Display(Name = "Preço Unitário")]
        [Column(TypeName = "decimal(5, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]

        public decimal Price { get; set; }
        public int Quantidade { get; set; }
        public string Fornecedor { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        public decimal TotalCal( decimal pPrice, int quantidade)
        {
            Quantidade = quantidade;
            Price = pPrice ;
            return Price * Quantidade;
        }
    }
}