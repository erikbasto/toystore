import { Component, Inject } from '@angular/core';
import { ProductService } from '../services/product.service'

@Component({
  templateUrl: './fetchproduct.component.html'
})

export class FetchProductComponent {
  public prodList: ProductData[];


  constructor(private _productService: ProductService) {
    this.getProducts();
  }
  getProducts() {
    this._productService.getProducts().subscribe(
      data => this.prodList = data
    )
  }

  delete(productId) {
    var ans = confirm("Do you want to delete product with Id: " + productId);
    if (ans) {
      this._productService.deleteProduct(productId).subscribe((data) => {
        this.getProducts();
      }, error => console.error(error))
    }
  }
}

interface ProductData {
  productId: number;
  name: string;
  age: number;
  company: string;
  price: number;
}

