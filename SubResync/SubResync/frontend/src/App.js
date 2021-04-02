import { useState, useEffect } from 'react'
import './App.css';
import axios from 'axios'
import Link from 'react-download-link'

function App() {

  const [file, setFile] = useState();
  const [offset, setOffset] = useState();
  const [url, setUrl] = useState();
  const [name, setName] = useState();
  const [last, setLast] = useState([]);


  useEffect(() => {
    async function getData(){
      const response= await axios.get('http://localhost:53636/api/Upload');
      const lastDownloads = response.data.pathName.map(item => {
        let name = item.split('\\');
        return{
          url: `http://localhost:53636/${item}`,
          name: name[2]
        }
      })
      setLast(lastDownloads)
      console.log(last)
    }
    getData();
  },[url])



  const handleForm = async () => {
    const data = new FormData();
    data.append('str', file);
    data.append('offset', offset)
    try{
      const response = await axios.post("http://localhost:53636/api/Upload",data);
      setUrl(response.data.url)
      let name = response.data.url.split('/')
      setName(name[5])
    }catch(err){
      console.log(err.message)
    }
  }

  async function getFileFromUrl(url){
    try{
      const response = await axios.get(`${url}`);
      return response.data;
    }catch(err){
      console.log(err.message)
    }
  }

  return (
    <>
    <div className="container">
      <div className="filter">
      <div className="card">
          
            <input name="file" className="input" onChange={(e) => setFile(e.target.files[0])} type="file" />
            <input type="text" placeholder="Digite o deslocamento" name="offset" className="offset" onChange={(e) => setOffset(e.target.value)} />
            <a className="button" href="#" onClick={handleForm}>Fazer mudanças</a>
            {url && <Link label="Download" filename={name} exportFile={() => getFileFromUrl(url) } />}
      </div>
      </div>
    </div>
    <div className="lastDownloads">
        <h2>Ultimas Conversões</h2>
        {last.map((item,index) => {
          return (
            <div className="line">
            <p>{item.name}</p>
            <Link label="Download" filename={item.name} exportFile={() => getFileFromUrl(item.url)} />
            </div>
          )
        })}
    </div>
    </>
  );
}

export default App;
