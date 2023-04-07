import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  URL: string = `${environment.serverUrl}/api/product`;
  constructor(private http: HttpClient) { }
}
