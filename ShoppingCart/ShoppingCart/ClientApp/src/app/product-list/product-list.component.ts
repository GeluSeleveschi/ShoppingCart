import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../product.model';
import { ToastrNotificationService } from '../toastr-notification.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productList: Product[];

  constructor(private productService: ProductService, private toastr: ToastrNotificationService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts = () => {
    this.productService.getProducts().subscribe({
      next: (resp) => this.productList = resp as Product[],
      error: (err) => {
        this.toastr.showError('Something went wrong', 'Product List');
        console.log(err);
      }
    })
  }

}
