import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ProductService } from '../product.service';
import { Product } from '../product.model';
import { ToastrNotificationService } from '../toastr-notification.service';

@Component({
  selector: 'app-add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.css']
})
export class AddEditProductComponent implements OnInit {
  productForm: FormGroup;
  product: Product;

  constructor(private productService: ProductService, private fb: FormBuilder,
    private toastr: ToastrNotificationService) {
  }

  ngOnInit(): void {
    this.createProductForm();
  }

  createProductForm = () => {
    return this.productForm = this.fb.group({
      id: new FormControl(0),
      name: new FormControl(),
      description: new FormControl(),
      price: new FormControl(),
      imagePath: new FormControl()
    })
  }

  submit() {
    const formData = new FormData();
    formData.append('id', this.productForm.value.id);
    formData.append('name', this.productForm.value.name);
    formData.append('description', this.productForm.value.description);
    formData.append('price', this.productForm.value.price);
    formData.append('imagePath', this.selectedFile);

    this.productService.addProduct(formData).subscribe(
      (response) => {
        console.log('Product created successfully');
        this.toastr.showSuccess('Product added successfully.', 'Product')
      },
      (error) => {
        console.log('Product creation failed');
        this.toastr.showError('Something went wrong.', 'Product')
      }
    );
  }

  validateControl = (controlName: string) => {
    if (this.productForm.get(controlName)?.invalid && this.productForm.get(controlName)?.touched)
      return true;

    return false;
  }

  hasError = (controlName: string, errorName: string) => {
    if (this.productForm.get(controlName)?.hasError(errorName))
      return true;

    return false;
  }

  uploadPhoto(file: any) {
    debugger;
    const formData = new FormData();

    formData.append('file', file, file.name);
    this.product.imagePath = file;
  }

  selectedFile: File;

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

}
