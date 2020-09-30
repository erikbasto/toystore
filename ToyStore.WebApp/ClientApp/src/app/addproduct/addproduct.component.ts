import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchProductComponent } from '../fetch-product/fetchproduct.component';
import { ProductService } from '../services/product.service';

@Component({
  templateUrl: './addproduct.component.html'
})

export class CreateProductComponent implements OnInit {
  productForm: FormGroup;
  title: string = "Create";
  productId: number;
  errorMessage: any;

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _productService: ProductService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.productId = this._avRoute.snapshot.params["id"];
    }

    this.productForm = this._fb.group({
      productId: 0,
      name: ['', [Validators.required]],
      price: ['', [Validators.required]],
      company: ['', [Validators.required]],
      age: ['', [Validators.max(100)]],
      description: ['', [Validators.maxLength(100)]]
    })
  }

  ngOnInit() {

    if (this.productId > 0) {
      this.title = "Edit";
      this._productService.getProductById(this.productId)
        .subscribe(resp => this.productForm.setValue(resp)
          , error => this.errorMessage = error);
    }

  }

  save() {

    if (!this.productForm.valid) {
      return;
    }

    if (this.title == "Create") {
      this._productService.saveProduct(this.productForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-product']);
        }, error => this.errorMessage = error)
    }
    else if (this.title == "Edit") {
      this._productService.updateProduct(this.productForm.value)
        .subscribe((data) => {
          this._router.navigate(['/fetch-product']);
        }, error => this.errorMessage = error)
    }
  }

  cancel() {
    this._router.navigate(['/fetch-product']);
  }

  get name() { return this.productForm.get('name'); }
  get price() { return this.productForm.get('price'); }
  get company() { return this.productForm.get('company'); }
  get age() { return this.productForm.get('age'); }
  get description() { return this.productForm.get('description'); }
}
