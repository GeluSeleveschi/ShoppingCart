import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.css']
})
export class AddEditProductComponent implements OnInit {
  productForm: FormGroup;

  constructor(private productService: ProductService, private fb: FormBuilder) {

  }

  ngOnInit(): void {
    this.createProductForm();
  }

  createProductForm = () => {
    return this.productForm = this.fb.group({
      id: new FormControl(),
      name: new FormControl(),
      description: new FormControl(),
      price: new FormControl(),
      imagePath: new FormControl()
    })
  }
}
