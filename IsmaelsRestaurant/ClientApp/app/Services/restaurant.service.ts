import { RestaurantModel } from './../components/restaurant/restaurant.model';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class RestaurantService {

  private uriApi:string = "/api/restaurants/";

  constructor(private http: Http) { }

  searchRestaurants(search: string){
    return this.http.get(this.uriApi + "search/" + search)
      .map(res => res.json());
  }

  getRestaurants(){
    return this.http.get(this.uriApi)
      .map(res => res.json());
  }

  getRestaurant(id: number){
    return this.http.get(this.uriApi + id)
      .map(res => res.json());
  }

  saveRestaurant(restaurant: RestaurantModel){
    return this.http.post(this.uriApi, restaurant)
      .map(res => res.json());
  }

  updateRestaurant(restaurant: RestaurantModel){
    return this.http.put(this.uriApi + restaurant.id, restaurant)
      .map(res => res.json());
  }

  deleteRestaurant(restaurant: RestaurantModel){
    return this.http.delete(this.uriApi + restaurant.id)
      .map(res => res.json());
  }
}