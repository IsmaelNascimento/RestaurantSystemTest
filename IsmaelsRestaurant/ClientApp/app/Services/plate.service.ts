import { PlateModel } from './../components/plate/plate.model';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class PlateService {

  private uriApi:string = "/api/plates/";

  constructor(private http: Http) { }

  searchPlates(search: string){
    return this.http.get(this.uriApi + "search/" + search)
      .map(res => res.json());
  }

  getPlates(){
    return this.http.get(this.uriApi)
      .map(res => res.json());
  }

  savePlate(plate: PlateModel){
    return this.http.post(this.uriApi, plate)
      .map(res => res.json());
  }

  updatePlate(plate: PlateModel){
    return this.http.put(this.uriApi + plate.id, plate)
      .map(res => res.json());
  }

  deletePlate(plate: PlateModel){
    return this.http.delete(this.uriApi + plate.id)
      .map(res => res.json());
  }
}